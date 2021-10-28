using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSM
{
    public enum Status
    {
        NotReadyToSwitchOn,
        ReadyToSwitchOn,
        SwitchedOn,
        OperationEnabled,
        Fault,
        VoltageEnabled,
        QuickStop,
        SwitchOnDisabled,
        Warning
    }

    public partial class Form1 : Form
    {
        FullStateMachine fullStateMachine;
        Motor motor;

        //command words as array
        int[] cw = new int[16];
        //status words as array
        //int[] sw = new int[16];

        bool faultReactionActiveFlag;

        public Form1()
        {
            InitializeComponent();
            fullStateMachine = new FullStateMachine(Status.NotReadyToSwitchOn);
            motor = new Motor();

            cw = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //sw = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            faultReactionActiveFlag = false;
            stateLabel.Text = "Not Ready To Switch On";
            faultResetBtn.Enabled = false;

            //-----FSM initialisation------

            //once FSM is initialised successfully
            //SW: xxxxxxxxx01x0000
            fullStateMachine.currentStatus = Status.SwitchOnDisabled;
            stateLabel.Text = "Initialised successfully. \nSwitch On Disabled";
            disableSwitchOnBtn.Enabled = false;
            switchOnBtn.Enabled = false;
            enableOperationBtn.Enabled = false;
            quickstopBtn.Enabled = false;
        }

        //This function is called when user changes a bit in the control word. Each control word controls a status transition.
        public void updateStatus()
        {
            //transition to "Fault Reaction Active" status
            if (faultReactionActiveFlag)
            {
                //SW: xxxxxxxxx0xx1111
                //sw = new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                fullStateMachine.currentStatus = Status.Warning;
                stateLabel.Text = "Fault Reaction Active";
                updateMotorVelocity(0);

                //----- Fault reaction code here -------

                //transition to "Fault" status
                faultReactionActiveFlag = false;
                //SW: xxxxxxxxx0xx1000
                //sw = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                fullStateMachine.currentStatus = Status.Fault;
                stateLabel.Text = "Fault";
                faultResetBtn.Enabled = true;
            }

            //CW: xxxxxxxxxxxxxx0x (transition to "Switch On Disabled" status)
            else if (cw.SequenceEqual(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                if (fullStateMachine.currentStatus == Status.ReadyToSwitchOn || fullStateMachine.currentStatus == Status.SwitchedOn || fullStateMachine.currentStatus == Status.OperationEnabled || fullStateMachine.currentStatus == Status.QuickStop)
                {
                    //SW: xxxxxxxxx1xx0000
                    //sw = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.SwitchOnDisabled;
                    stateLabel.Text = "Switch On Disabled";
                    updateMotorVelocity(0);
                }
                else
                {
                    logErrorMsg();
                }
            }

            //CW: xxxxxxxxxxxxx01x (transition to "Switch On Disabled" OR "Quickstop Active" status)
            else if (cw.SequenceEqual(new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                if (fullStateMachine.currentStatus == Status.ReadyToSwitchOn || fullStateMachine.currentStatus == Status.SwitchedOn)
                {
                    //SW: xxxxxxxxx1xx0000
                    //sw = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.SwitchOnDisabled;
                    stateLabel.Text = "Switch On Disabled";
                    updateMotorVelocity(0);
                }
                else if (fullStateMachine.currentStatus == Status.OperationEnabled)
                {
                    //SW: xxxxxxxxx0xx0111
                    //sw = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.QuickStop;
                    stateLabel.Text = "Quick Stop Active";
                    updateMotorVelocity(0);
                }
                else
                {
                    logErrorMsg();
                }
            }

            //CW: xxxxxxxx1xxxxxxx (transition to "Switch On Disabled" status FROM FAULT)
            else if (cw.SequenceEqual(new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                if (fullStateMachine.currentStatus == Status.Fault)
                {
                    //SW: xxxxxxxxx1xx0000
                    //sw = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.SwitchOnDisabled;
                    stateLabel.Text = "Switch On Disabled";
                    updateMotorVelocity(0);
                    cw[7] = 0;
                }
                else
                {
                    logErrorMsg();
                }
            }

            //CW: xxxxxxxxxxxxx110 (transition to "ready to switch on" status)
            else if (cw.SequenceEqual(new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                if(fullStateMachine.currentStatus == Status.SwitchOnDisabled || fullStateMachine.currentStatus == Status.SwitchedOn || fullStateMachine.currentStatus == Status.OperationEnabled)
                {
                    //SW: xxxxxxxxx01x0001
                    //sw = new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.ReadyToSwitchOn;
                    stateLabel.Text = "Ready To Switch On";
                    updateMotorVelocity(0);
                }
                else
                {
                    logErrorMsg();
                }
            }

            //CW: xxxxxxxxxxxxx111 (transition to "Switched On" status)
            else if (cw.SequenceEqual(new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                if (fullStateMachine.currentStatus == Status.ReadyToSwitchOn || fullStateMachine.currentStatus == Status.OperationEnabled)
                {
                    //SW: xxxxxxxxx01x0011
                    //sw = new int[] { 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.SwitchedOn;
                    stateLabel.Text = "Switched On";
                    updateMotorVelocity(0);
                }
                else
                {
                    logErrorMsg();
                }
            }

            //CW: xxxxxxxxxxxx1111 (transition to "Operation Enabled" status)
            else if (cw.SequenceEqual(new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {                
                if (fullStateMachine.currentStatus == Status.SwitchedOn)
                {
                    //SW: xxxxxxxxx01x0111
                    //sw = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fullStateMachine.currentStatus = Status.OperationEnabled;
                    stateLabel.Text = "Operation Enabled";
                    updateMotorVelocity(decimal.ToInt16(desiredMotorVelocityInput.Value));
                }
                else
                {
                    logErrorMsg();
                }
            }
        }

        public void updateMotorVelocity(Int16 desiredMotorVelocity)
        {
            motorVelocityLbl.Text = desiredMotorVelocity.ToString();
        }

        //Creates error message if user tries to perform an invalid status transition.
        public void logErrorMsg()
        {
            Console.WriteLine("Current status cannot transition to input status directly.");
        }

        #region Control event handlers
        //Switch on button clicked -> transition to "Switched On" status
        private void switchOnBtn_Click(object sender, EventArgs e)
        {
            switchOnBtn.Enabled = false;
            quickstopBtn.Enabled = false;
            disableSwitchOnBtn.Enabled = true;
            enableSwitchOnBtn.Enabled = true;
            enableOperationBtn.Enabled = true;

            //CW: xxxxxxxxxxxxx111 
            cw = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        //Enable Switch On button clicked -> transtion to "Ready To Switch On" status
        private void enableSwitchOnBtn_Click(object sender, EventArgs e)
        {
            quickstopBtn.Enabled = false;
            enableSwitchOnBtn.Enabled = false;
            enableOperationBtn.Enabled = false;
            disableSwitchOnBtn.Enabled = true;
            switchOnBtn.Enabled = true;

            //CW: xxxxxxxxxxxxx110
            cw = new int[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        //CW quickstop button clicked -> transition to "Quickstop Active" status
        private void quickstopBtn_Click(object sender, EventArgs e)
        {
            quickstopBtn.Enabled = false;
            enableOperationBtn.Enabled = false;
            enableSwitchOnBtn.Enabled = false;
            switchOnBtn.Enabled = false;
            disableSwitchOnBtn.Enabled = true;

            //CW: xxxxxxxxxxxxx01x 
            cw = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        //Enable operation button clicked -> transition to "Operation Enabled" status
        private void enableOperationBtn_Click(object sender, EventArgs e)
        {
            enableOperationBtn.Enabled = false;
            disableSwitchOnBtn.Enabled = true;
            enableSwitchOnBtn.Enabled = true;
            switchOnBtn.Enabled = true;
            quickstopBtn.Enabled = true;

            //CW: xxxxxxxxxxxx1111 
            cw = new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        //Disable Switch On button clicked -> transition to "Switch On Disabled" status
        private void disableSwitchOnBtn_Click(object sender, EventArgs e)
        {
            disableSwitchOnBtn.Enabled = false;
            switchOnBtn.Enabled = false;
            quickstopBtn.Enabled = false;
            faultResetBtn.Enabled = false;
            enableOperationBtn.Enabled = false;
            enableSwitchOnBtn.Enabled = true;

            //CW: xxxxxxxxxxxxxx0x 
            cw = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        //fault reset button clicked
        private void faultResetBtn_Click(object sender, EventArgs e)
        {
            faultResetBtn.Enabled = false;
            enableSwitchOnBtn.Enabled = true;

            //CW: xxxxxxx1xxxxxxxx 
            cw = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            updateStatus();
        }

        private void desiredMotorVelocityInput_ValueChanged(object sender, EventArgs e)
        {
            if(this.fullStateMachine.currentStatus == Status.OperationEnabled)
            {
                updateMotorVelocity(decimal.ToInt16(desiredMotorVelocityInput.Value));
            }
        }

        //Simulate a fault 
        private void simulateFaultBtn_Click(object sender, EventArgs e)
        {
            disableSwitchOnBtn.Enabled = false;
            enableSwitchOnBtn.Enabled = false;
            switchOnBtn.Enabled = false;
            enableOperationBtn.Enabled = false;
            quickstopBtn.Enabled = false;

            faultReactionActiveFlag = true;
            updateStatus();
        }
        #endregion
    }
}
