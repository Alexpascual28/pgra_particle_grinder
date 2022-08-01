using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace FinalGrinderRobotApp.MVVM.Model
{
    public class RobotModel{}

    // DataPanel Class: contains data for all componets of input section of UI
    public class DataPanel : INotifyPropertyChanged
    {
        private int targetOutputVialWeight;
        private int inputVialWeight;

        private string? exportPath;
        private bool exportState;

        private bool startState;
        private bool stopState;
        private bool resetState;

        private string robotAction;

        public int TargetOutputVialWeight 
        {
            get 
            {
                if (targetOutputVialWeight < 0)
                {
                    targetOutputVialWeight = 0;
                }

                if (targetOutputVialWeight > MaxOutputVialWeight)
                {
                    targetOutputVialWeight = MaxOutputVialWeight;
                }
                return targetOutputVialWeight; 
            }
            set 
            { 
                if (targetOutputVialWeight != value)
                {
                    targetOutputVialWeight = value;
                    RaisePropertyChanged("TargetOutputVialWeight");
                    RaisePropertyChanged("InputVialWeight");
                    RaisePropertyChanged("MaxOutputVialWeight");
                } 
            } 
        }

        public int InputVialWeight
        {
            get {
                if (inputVialWeight < 0)
                {
                    inputVialWeight = 0;
                }

                if (inputVialWeight > 1000000000)
                {
                    inputVialWeight = 1000000000;
                }

                return inputVialWeight; 
            }
            set
            {
                if (inputVialWeight != value)
                {
                    inputVialWeight = value;
                    RaisePropertyChanged("InputVialWeight");
                    RaisePropertyChanged("TargetOutputVialWeight");
                    RaisePropertyChanged("MaxOutputVialWeight");
                }
            }
        }

        public int MaxOutputVialWeight
        {
            get { return (inputVialWeight / 3); }
        }

        public string ExportPath
        {
            get { return exportPath; }
            set
            {
                if (exportPath != value)
                {
                    exportPath = value;
                    RaisePropertyChanged("ExportPath");
                    RaisePropertyChanged("ExportState");
                }
            }
        }

        public bool ExportState
        {
            get { return exportState; }
            set
            {
                if (exportState != value)
                {
                    exportState = value;
                    RaisePropertyChanged("ExportPath");
                    RaisePropertyChanged("ExportState");
                }
            }
        }

        public bool StartState
        {
            get { return startState; }
            set
            {
                if (startState != value)
                {
                    startState = value;
                    RaisePropertyChanged("StartState");
                }
            }
        }

        public bool StopState
        {
            get { return stopState; }
            set
            {
                if (stopState != value)
                {
                    stopState = value;
                    RaisePropertyChanged("StopState");
                }
            }
        }

        public bool ResetState
        {
            get { return resetState; }
            set
            {
                if (resetState != value)
                {
                    resetState = value;
                    RaisePropertyChanged("ResetState");
                }
            }
        }

        public string RobotAction
        {
            get { return robotAction; }
            set
            {
                if (robotAction != value)
                {
                    robotAction = value;
                    RaisePropertyChanged("RobotAction");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // InputRack Class: contains data for all componets of inputRack (number of vials etc)
    public class InputRack : INotifyPropertyChanged
    {
        private int inputVialNumber;
        private int usedVialNumber;

        public int InputVialNumber
        {
            get { return inputVialNumber; }
            set
            {
                if (inputVialNumber != value)
                {
                    inputVialNumber = value;
                    RaisePropertyChanged("InputVialNumber");
                    RaisePropertyChanged("TotalVialNumber");
                }
            }
        }

        public int UsedVialNumber
        {
            get { return usedVialNumber; }
            set
            {
                if (usedVialNumber != value)
                {
                    usedVialNumber = value;
                    RaisePropertyChanged("UsedVialNumber");
                    RaisePropertyChanged("TotalVialNumber");
                }
            }
        }

        public int TotalVialNumber
        {
            get { return inputVialNumber + usedVialNumber; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // OutputRack Class: contains data for all componets of outputRack (number of vials etc)
    public class OutputRack : INotifyPropertyChanged
    {
        private int emptyVialNumber;
        private int outputVialNumber;

        public int EmptyVialNumber
        {
            get { return emptyVialNumber; }
            set
            {
                if (emptyVialNumber != value)
                {
                    emptyVialNumber = value;
                    RaisePropertyChanged("EmptyVialNumber");
                    RaisePropertyChanged("TotalVialNumber");
                }
            }
        }

        public int OutputVialNumber
        {
            get { return outputVialNumber; }
            set
            {
                if (outputVialNumber != value)
                {
                    outputVialNumber = value;
                    RaisePropertyChanged("OutputVialNumber");
                    RaisePropertyChanged("TotalVialNumber");
                }
            }
        }

        public int TotalVialNumber
        {
            get { return outputVialNumber + emptyVialNumber; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // Grinder Class: contains data for all componets of grinder module
    public class Grinder : INotifyPropertyChanged
    {
        private bool isBusy; // Is the module active?
        private bool isEmpty; // Is the module loaded with a vial?
        private bool isDone; // Is the module finished processing the vial?
        private int progressValue;
        private DispatcherTimer timer;
        private int counter;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (isEmpty != value)
                {
                    isEmpty = value;
                    RaisePropertyChanged("IsEmpty");
                }
            }
        }

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone != value)
                {
                    isDone = value;
                    RaisePropertyChanged("IsDone");
                }
            }
        }

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                if (progressValue != value)
                {
                    progressValue = value;
                    RaisePropertyChanged("ProgressValue");
                }
            }
        }

        public DispatcherTimer Timer
        {
            get { return timer; }
            set
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(200);
                RaisePropertyChanged("Timer");
            }
        }

        public int Counter
        {
            get { return counter; }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    RaisePropertyChanged("Counter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // Dispenser Class: contains data for all componets of dispenser module
    public class Dispenser : INotifyPropertyChanged
    {
        private bool isBusy; // Is the module active?
        private bool isEmpty; // Is the module loaded with a vial?
        private bool isDone; // Is the module finished processing the vial?
        private int outputVialDispenseNumber;
        private string dispenserAction;
        private string dispensingString;

        private DispatcherTimer timer;
        private int counter;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (isEmpty != value)
                {
                    isEmpty = value;
                    RaisePropertyChanged("IsEmpty");
                }
            }
        }

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone != value)
                {
                    isDone = value;
                    RaisePropertyChanged("IsDone");
                }
            }
        }

        public int OutputVialDispenseNumber
        {
            get { return outputVialDispenseNumber; }
            set
            {
                if (outputVialDispenseNumber != value)
                {
                    outputVialDispenseNumber = value;
                    RaisePropertyChanged("OutputVialDispenseNumber");
                }
            }
        }

        public string DispenserAction
        {
            get { return dispenserAction; }
            set
            {
                if (dispenserAction != value)
                {
                    dispenserAction = value;
                    RaisePropertyChanged("DispenserAction");
                }
            }
        }

        public string DispensingString
        {
            get { return dispensingString; }
            set
            {
                if (dispensingString != value)
                {
                    dispensingString = value;
                    RaisePropertyChanged("DispensingString");
                }
            }
        }

        public DispatcherTimer Timer
        {
            get { return timer; }
            set
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                RaisePropertyChanged("Timer");
            }
        }

        public int Counter
        {
            get { return counter; }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    RaisePropertyChanged("Counter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // Weight Class: contains data for all componets of balance (weighting) module
    public class Weight : INotifyPropertyChanged
    {
        private bool isBusy; // Is the module active?
        private bool isEmpty; // Is the module loaded with a vial?
        private bool isDone; // Is the module finished processing the vial?
        private string outputVialName;
        private int weightValue;

        private DispatcherTimer timer;
        private int counter;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set
            {
                if (isEmpty != value)
                {
                    isEmpty = value;
                    RaisePropertyChanged("IsEmpty");
                }
            }
        }

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone != value)
                {
                    isDone = value;
                    RaisePropertyChanged("IsDone");
                }
            }
        }

        public string OutputVialName
        {
            get { return outputVialName; }
            set
            {
                if (outputVialName != value)
                {
                    outputVialName = value;
                    RaisePropertyChanged("OutputVialName");
                }
            }
        }

        public int WeightValue
        {
            get { return weightValue; }
            set
            {
                if (weightValue != value)
                {
                    weightValue = value;
                    RaisePropertyChanged("WeightValue");
                }
            }
        }

        public DispatcherTimer Timer
        {
            get { return timer; }
            set
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                RaisePropertyChanged("Timer");
            }
        }

        public int Counter
        {
            get { return counter; }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    RaisePropertyChanged("Counter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

    // RobotArm Class: contains data for all componets of robotArm module
    public class RobotArm : INotifyPropertyChanged
    {
        private bool isBusy;
        private string ra0; // All 5 possible robot actions (ra0 - ra4)
        private string ra1;
        private string ra2;
        private string ra3;
        private string ra4;

        private DispatcherTimer timer;
        private int counter;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public string RA0
        {
            get { return ra0; }
            set
            {
                if (ra0 != value)
                {
                    ra0 = value;
                    RaisePropertyChanged("RA0");
                }
            }
        }

        public string RA1
        {
            get { return ra1; }
            set
            {
                if (ra1 != value)
                {
                    ra1 = value;
                    RaisePropertyChanged("RA1");
                }
            }
        }

        public string RA2
        {
            get { return ra2; }
            set
            {
                if (ra2 != value)
                {
                    ra2 = value;
                    RaisePropertyChanged("RA2");
                }
            }
        }

        public string RA3
        {
            get { return ra3; }
            set
            {
                if (ra3 != value)
                {
                    ra3 = value;
                    RaisePropertyChanged("RA3");
                }
            }
        }

        public string RA4
        {
            get { return ra4; }
            set
            {
                if (ra4 != value)
                {
                    ra4 = value;
                    RaisePropertyChanged("RA4");
                }
            }
        }

        public DispatcherTimer Timer
        {
            get { return timer; }
            set
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                RaisePropertyChanged("Timer");
            }
        }

        public int Counter
        {
            get { return counter; }
            set
            {
                if (counter != value)
                {
                    counter = value;
                    RaisePropertyChanged("Counter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(property)); }
        }
    }

}
