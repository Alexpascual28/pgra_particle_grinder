using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FinalGrinderRobotApp.MVVM.Model;

namespace FinalGrinderRobotApp.MVVM.ViewModel
{
    internal class RobotViewModel
    {
        public RobotViewModel()
        {
            LoadData();
            Task t = new Task(() => MainLoop());
            t.Start();
        }

        // Starting all public component classes...
        public DataPanel dataPanel
        {
            get;
            set;
        }

        public InputRack inputRack
        {
            get;
            set;
        }

        public OutputRack outputRack1
        {
            get;
            set;
        }

        public OutputRack outputRack2
        {
            get;
            set;
        }

        public OutputRack outputRack3
        {
            get;
            set;
        }

        public Grinder grinder
        {
            get;
            set;
        }

        public Dispenser dispenser
        {
            get;
            set;
        }

        public Weight weight
        {
            get;
            set;
        }

        public RobotArm robotArm
        {
            get;
            set;
        }

        // To initialize data at program start (assigning values to every method)
        public void LoadData()
        {
            DataPanel _dataPanel = new DataPanel
            {
                TargetOutputVialWeight = 50,
                InputVialWeight = 900,
                ExportPath = @"C:\OutputData\doc.csv",
                ExportState = false,
                StartState = false,
                StopState = false,
                ResetState = false,
                RobotAction = "Waiting for START"
            };

            InputRack _inputRack = new InputRack { InputVialNumber = 96, UsedVialNumber = 0 };
            OutputRack _outputRack1 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };
            OutputRack _outputRack2 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };
            OutputRack _outputRack3 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };

            Grinder _grinder = new Grinder { IsBusy = false, IsEmpty = true, IsDone = false, ProgressValue = 0, Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
            Dispenser _dispenser = new Dispenser { IsBusy = false, IsEmpty = true, IsDone = false, OutputVialDispenseNumber = 0, DispenserAction = "White", DispensingString = "", Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
            Weight _weight = new Weight { IsBusy = false, IsEmpty = true, IsDone = false, OutputVialName = "Empty", WeightValue = 0, Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
            RobotArm _robotArm = new RobotArm { IsBusy = false, RA0 = "White", RA1 = "White", RA2 = "White", RA3 = "White", RA4 = "White", Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };

            dataPanel = _dataPanel;
            inputRack = _inputRack;
            outputRack1 = _outputRack1;
            outputRack2 = _outputRack2;
            outputRack3 = _outputRack3;
            grinder = _grinder;
            dispenser = _dispenser;
            weight = _weight;
            robotArm = _robotArm;

            using (StreamWriter fileTitle = new StreamWriter(dataPanel.ExportPath, false))
            {
                fileTitle.WriteLine("Vial Number , Weight in mg");
            }
        }

        // Main loop. Instantiated as a Task at startup. Code works within while loop. 
        private void MainLoop()
        {
            // Loop will run until 288 output vials are achieved
            while ((outputRack1.OutputVialNumber + outputRack2.OutputVialNumber + outputRack3.OutputVialNumber) < 288)
            {
                // If Start button is checked, run this
                if (dataPanel.StartState == true)
                {
                    if (!robotArm.IsBusy) RobotAction0();           // From Input Rack to Grinder
                    if(!grinder.IsBusy) GrinderAction();            // Grinding...
                    Task.WaitAll(new Task[] { Task.Delay(3000) });  //Small delay to allow grinding to finish
                    RobotAction2();                                 // From Grinder to Dispenser
                    for(int i = 0; i < 3; i++) {                    // Loop for the 3 OutPut Vials
                        if (!robotArm.IsBusy) RobotAction1();       // From Output Rack to Balance
                        DispenseAction();                           // Dispensing...
                        WeightAction();                             // Weighting Material
                        if (!robotArm.IsBusy) RobotAction3();       // From Balance to Output Rack
                    }
                    if (!robotArm.IsBusy) RobotAction4();           // Used Input Vial from Dispenser to Input Rack
                } 
                else
                {
                    CheckStopStatus();
                }

                Task.WaitAll(new Task[] { Task.Delay(100) });
            }
        }

        // Manages Stop and reset buttons (not fully functional yet)
        private void CheckStopStatus()
        {
            if (dataPanel.ResetState == true)
            {
                dataPanel = new DataPanel
                {
                    TargetOutputVialWeight = 50,
                    InputVialWeight = 900,
                    ExportPath = @"C:\OutputData\doc.csv",
                    ExportState = false,
                    StartState = false,
                    StopState = false,
                    ResetState = false,
                    RobotAction = "Waiting for START"
                };
                inputRack = new InputRack { InputVialNumber = 96, UsedVialNumber = 0 };
                outputRack1 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };
                outputRack2 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };
                outputRack3 = new OutputRack { EmptyVialNumber = 96, OutputVialNumber = 0 };
                grinder = new Grinder { IsBusy = false, IsEmpty = true, IsDone = false, ProgressValue = 0, Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
                dispenser = new Dispenser { IsBusy = false, IsEmpty = true, IsDone = false, OutputVialDispenseNumber = 0, DispenserAction = "White", DispensingString = "", Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
                weight = new Weight { IsBusy = false, IsEmpty = true, IsDone = false, OutputVialName = "Empty", WeightValue = 0, Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
                robotArm = new RobotArm { IsBusy = false, RA0 = "White", RA1 = "White", RA2 = "White", RA3 = "White", RA4 = "White", Counter = 0, Timer = new System.Windows.Threading.DispatcherTimer() };
            }

            if (dataPanel.StopState == true)
            {
                /*if(dataPanel.ExportState == true) {
                File.WriteAllText(dataPanel.ExportPath, csv.ToString());
                }*/
                Application.Current.Shutdown();
            }
        }

        // From Input Rack to Grinder
        private void RobotAction0()
        {
            robotArm.IsBusy = true;
            grinder.IsEmpty = false;
            inputRack.InputVialNumber -= 1;
            robotArm.RA0 = "Green";
            dataPanel.RobotAction = "Moving Input Vial to Grinder";

            Task.WaitAll(new Task[] { Task.Delay(3000) });
            robotArm.IsBusy = false;
            robotArm.RA0 = "White";
            dataPanel.RobotAction = "";
            CheckStopStatus();
        }

        // From Output Rack to Balance
        private void RobotAction1()
        {
            robotArm.IsBusy = true;
            weight.IsEmpty = false;

            if (outputRack1.EmptyVialNumber > 0)
            {
                outputRack1.EmptyVialNumber -= 1;
            }
            else if (outputRack2.EmptyVialNumber > 0)
            {
                outputRack2.EmptyVialNumber -= 1;
            }
            else if (outputRack3.EmptyVialNumber > 0)
            {
                outputRack3.EmptyVialNumber -= 1;
            }

            robotArm.RA1 = "Green";
            dataPanel.RobotAction = "Moving Empty Output Vial to Weight";
            Task.WaitAll(new Task[] { Task.Delay(3000) });

            robotArm.RA1 = "White";
            dataPanel.RobotAction = "";
            robotArm.IsBusy = false;
            CheckStopStatus();
        }

        // From Grinder to Dispenser
        private void RobotAction2()
        {
            robotArm.IsBusy = true;
            grinder.IsEmpty = true;
            dispenser.IsEmpty = false;
            weight.Counter++;
            robotArm.RA2 = "Green";
            dataPanel.RobotAction = "Moving Grinded Input Vial to Dispense Station";
            grinder.ProgressValue = 0;
            dispenser.OutputVialDispenseNumber = 3;

            Task.WaitAll(new Task[] { Task.Delay(3000) });

            robotArm.RA2 = "White";
            dataPanel.RobotAction = "";
            grinder.IsBusy = false;
            robotArm.IsBusy = false;
            CheckStopStatus();
        }

        // From Balance to Output Rack
        private void RobotAction3()
        {
            robotArm.IsBusy = true;
            weight.IsEmpty = true;
            dataPanel.RobotAction = "Moving Full Output Vial to Output Rack";
            robotArm.RA3 = "Green";

            if (outputRack1.OutputVialNumber < 96)
            {
                outputRack1.OutputVialNumber += 1;
            }
            else if (outputRack2.OutputVialNumber < 96)
            {
                outputRack2.OutputVialNumber += 1;
            }
            else if (outputRack3.OutputVialNumber < 96)
            {
                outputRack3.OutputVialNumber += 1;
            }

            Task.WaitAll(new Task[] { Task.Delay(3000) });

            robotArm.RA3 = "White";
            dataPanel.RobotAction = "";
            weight.IsBusy = false;
            dispenser.IsBusy = false;
            robotArm.IsBusy = false;
            CheckStopStatus();
        }

        // Used Input Vial from Dispenser to Input Rack
        private void RobotAction4()
        {
            robotArm.IsBusy = true;
            dispenser.IsEmpty = true;
            dataPanel.RobotAction = "Moving Used Input Vial back to Input Rack";
            robotArm.RA4 = "Green";
            inputRack.UsedVialNumber += 1;
            Task.WaitAll(new Task[] { Task.Delay(3000) });
            robotArm.RA4 = "White";
            dataPanel.RobotAction = "";
            robotArm.IsBusy = false;
            CheckStopStatus();
        }

        // To Dispense Material
        private void DispenseAction()
        {
            dispenser.IsBusy = true;
            dispenser.IsDone = false;
            dataPanel.RobotAction = "Dispensing";
            dispenser.Counter = 0;
            dispenser.OutputVialDispenseNumber -= 1;

            dispenser.DispenserAction = "Green";
            dispenser.DispensingString = "Dispensing";

            Task.WaitAll(new Task[] { Task.Delay(2000) });

            if (dispenser.OutputVialDispenseNumber == 0) dispenser.IsDone = true;
            dispenser.DispenserAction = "White";
            dataPanel.RobotAction = "";
            dispenser.DispensingString = "";
            CheckStopStatus();
        }
        
        // To Measure Weight of Material
        private void WeightAction()
        {
            Random rand = new Random();

            weight.IsBusy = true;
            weight.IsDone = false;
            dataPanel.RobotAction = "Measuring Weight";
            weight.OutputVialName = string.Format("{0}({1})", weight.Counter, dispenser.OutputVialDispenseNumber);
            weight.WeightValue = rand.Next(dataPanel.TargetOutputVialWeight + 2, dataPanel.TargetOutputVialWeight + 5);

            if (dataPanel.ExportState == true) {
                AddContent(weight.OutputVialName, weight.WeightValue.ToString());
                dataPanel.RobotAction = "Writing to File";
                Task.WaitAll(new Task[] { Task.Delay(1000) });
            }

            Task.WaitAll(new Task[] { Task.Delay(1000) });

            weight.IsDone = true;
            dataPanel.RobotAction = "";
        }

        // For Exporting Content to Document
        private void AddContent(string vialNum, string vialWeight)
        {
            using (StreamWriter fileContent = new StreamWriter(dataPanel.ExportPath, true))
            {
                fileContent.WriteLine(vialNum + "," + vialWeight);
            }
        }

        // To Grind the Material
        private void GrinderAction()
        {
            grinder.IsBusy = true;
            grinder.IsDone = false;
            grinder.ProgressValue = 0;
            dataPanel.RobotAction = "Grinding Material";
            grinder.Timer.Tick += grinder_Tick;
            grinder.Timer.Start();
        }

        // To Manage Dispatcher Timer of Grinder
        void grinder_Tick(object sender, EventArgs e)
        {
            if (grinder.Counter < 10)
            {
                grinder.ProgressValue += 10;
                grinder.Counter++;
            }
            else
            {
                grinder.IsDone = true;
                grinder.Counter = 0;
                dataPanel.RobotAction = "";
                grinder.Timer.Stop();
                CheckStopStatus();
            }
        }
    }
}
