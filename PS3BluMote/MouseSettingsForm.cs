using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS3BluMote
{
    public partial class MouseSettingsForm : Form
    {
        private readonly String SETTINGS_DIRECTORY = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\PS3BluMote\\";
        private readonly String SETTINGS_FILE = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\PS3BluMote\\settings.ini";
        private int increment = 5;
        private const String SETTINGS_VERSION = "2.0";

        private PS3Remote remote = null;
        private System.Timers.Timer timerRepeat = null;
        private System.Timers.Timer timerFindBtAddress = null;

        private string insertSound = "";
        private string removeSound = "";
        private PS3Remote.Button lastButton;

        public MouseSettingsForm()
        {

            InitializeComponent();

            timerRepeat = new System.Timers.Timer();
            timerRepeat.Interval = int.Parse(txtRepeatInterval.Text);
            timerRepeat.Elapsed += new System.Timers.ElapsedEventHandler(timerRepeat_Elapsed);



            buttonDump.Visible = DebugLog.isLogging;

            // Finding BT Address of the remote for Hibernation
            if (comboBtAddr.Text.Length != 12 && comboBtAddr.Text.Length != 17)
            {
                UpdateBtAddrList(1000);
            }
            else
            {
                comboBtAddr.Items.Clear();
                comboBtAddr.Items.Add(comboBtAddr.Text);
                comboBtAddr.Items.Add("Search again");
                comboBtAddr.Enabled = true;
            }

            // Saving Device Insertion sounds
            try
            {
                string s;
                bool save = false;
                s = RegUtils.GetDevConnectedSound();
                if (insertSound.Length == 0 || (insertSound != s && s.Length > 0))
                {
                    insertSound = s;
                    save = true;
                }
                s = RegUtils.GetDevDisconnectedSound();
                if (removeSound.Length == 0 || (removeSound != s && s.Length > 0))
                {
                    removeSound = s;
                    save = true;
                }
            }
            catch
            {
                if (DebugLog.isLogging) DebugLog.write("Unexpected error while trying to save Devices insertion/remove sounds.");
            }

            // Restoring Device Insertion sounds in case they have been left blank
            try
            {
                string s;
                s = RegUtils.GetDevConnectedSound();
                if (s.Length == 0 && insertSound.Length > 0) RegUtils.SetDevConnectedSound(insertSound);
                s = RegUtils.GetDevDisconnectedSound();
                if (s.Length == 0 && removeSound.Length > 0) RegUtils.SetDevDisconnectedSound(removeSound);
            }
            catch
            {
                if (DebugLog.isLogging) DebugLog.write("Unexpected error while trying to restore Devices insertion/remove sounds.");
            }

            try
            {
                int hibMs;
                try
                {
                    hibMs = System.Convert.ToInt32(txtMinutes.Text) * 60 * 1000;
                }
                catch
                {
                    if (DebugLog.isLogging) DebugLog.write("Error while parsing Hibernation Interval, taking Default 3 Minutes");
                    txtMinutes.Text = "3";
                    hibMs = 180000;
                }
                remote = new PS3Remote(int.Parse(txtVendorId.Text.Remove(0, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(txtProductId.Text.Remove(0, 2), System.Globalization.NumberStyles.HexNumber));

                remote.BatteryLifeChanged += new EventHandler<EventArgs>(remote_BatteryLifeChanged);
                remote.ButtonDown += new EventHandler<PS3Remote.ButtonEventArgs>(remote_ButtonDown);
                remote.ButtonReleased += new EventHandler<PS3Remote.ButtonEventArgs>(remote_ButtonReleased);

                remote.Connected += new EventHandler<EventArgs>(remote_Connected);
                remote.Disconnected += new EventHandler<EventArgs>(remote_Disconnected);
                remote.Hibernated += new EventHandler<EventArgs>(remote_Hibernated);
                remote.Awake += new EventHandler<EventArgs>(remote_Connected);

                remote.connect();

                remote.btAddress = comboBtAddr.Text;
                remote.hibernationInterval = hibMs;
                remote.hibernationEnabled = cbHibernation.Enabled && cbHibernation.Checked;
            }
            catch
            {
                MessageBox.Show("An error occured whilst attempting to load the remote.", "PS3BluMote: Remote error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TimerFindBtAddress_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerFindBtAddress.Stop();
            if (InvokeRequired)
            {
                this.comboBtAddr.Invoke((MethodInvoker)delegate
                {
                    comboBtAddr.Text = "Searching";
                    comboBtAddr.Enabled = false;
                });
            }

            List<string> btAddr = FindBtAddress.Find(txtProductId.Text.Remove(0, 2), txtVendorId.Text.Remove(0, 2));
            if (InvokeRequired)
            {
                this.comboBtAddr.Invoke((MethodInvoker)delegate
                {
                    comboBtAddr.Items.Clear();
                    foreach (string addr in btAddr) comboBtAddr.Items.Add(BTUtils.FormatBtAddress(addr, null, "C"));
                    comboBtAddr.Items.Add("Search again");
                    if (comboBtAddr.Text.Length != 12 && comboBtAddr.Text.Length != 17 && btAddr.Count == 1)
                    {
                        comboBtAddr.Text = BTUtils.FormatBtAddress(btAddr[0], null, "C");
                    }
                    else
                    {
                        comboBtAddr.Text = "";
                    }
                    comboBtAddr.Enabled = true;
                });
            }

        }

        private void cbDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            DebugLog.isLogging = cbDebugMode.Checked;
            buttonDump.Visible = DebugLog.isLogging;
        }

        private void cbHibernation_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBtAddr.Text.Length == 12 || comboBtAddr.Text.Length == 17 && remote != null) remote.hibernationEnabled = cbHibernation.Checked;
            else if (cbHibernation.Checked && remote != null)
            {
                MessageBox.Show("Fill in the BT Address field with a correct value before attempting to enable hibernation.", "PS3BluMote: Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbHibernation.Checked = false;
                remote.hibernationEnabled = false;
            }
        }

        private void llblOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "explorer.exe";
            prc.StartInfo.Arguments = SETTINGS_DIRECTORY;
            prc.Start();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void remote_BatteryLifeChanged(object sender, EventArgs e)
        {
            notifyIcon.Text = "PS3BluMote: Connected + (Battery: " + remote.getBatteryLife.ToString() + "%).";

            if (DebugLog.isLogging) DebugLog.write("Battery life: " + remote.getBatteryLife.ToString() + "%");
        }

        private void remote_ButtonDown(object sender, PS3Remote.ButtonEventArgs e)
        {
            if (DebugLog.isLogging) DebugLog.write("Button down: " + e.button.ToString());

            int y = 0;
            int x = 0;

            switch (e.button)
            {
                case PS3Remote.Button.Arrow_Up:
                    y -= increment;
                    break;
                case PS3Remote.Button.Arrow_Down:
                    y += increment;
                    break;
                case PS3Remote.Button.Arrow_Left:
                    x -= increment;
                    break;
                case PS3Remote.Button.Arrow_Right:
                    x += increment;
                    break;
                case PS3Remote.Button.R1:
                    increment++;
                    if (increment >= 100)
                        increment = 5;
                    break;
                case PS3Remote.Button.L1:
                    increment--;
                    if (increment <= 0)
                        increment = 5;
                    break;
                case PS3Remote.Button.Enter:
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                    return;
                case PS3Remote.Button.PopUp_Menu:
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                    return;
            }

            lastButton = e.button;

            if (x != 0 || y != 0)
            {
                //keyboard.sendKeysDown(mapping.keysMapped);
                //keyboard.releaseLastKeys();

                var position = MouseOperations.GetCursorPosition();
                position.X += x;
                position.Y += y;
                MouseOperations.SetCursorPosition(position);


                timerRepeat.Enabled = true;
                return;
            }

            //keyboard.sendKeysDown(mapping.keysMapped);
        }

        private void remote_ButtonReleased(object sender, PS3Remote.ButtonEventArgs e)
        {
            if (DebugLog.isLogging) DebugLog.write("Button released: " + e.button.ToString());

            if (timerRepeat.Enabled)
            {
                //if (DebugLog.isLogging) DebugLog.write("Keys repeat send off: { " + String.Join(",", keyboard.lastKeysDown.ToArray()) + " }");

                timerRepeat.Enabled = false;
                return;
            }

            switch (e.button)
            {
                //case PS3Remote.Button.Arrow_Up:
                //    y -= increment;
                //    break;
                //case PS3Remote.Button.Arrow_Down:
                //    y += increment;
                //    break;
                //case PS3Remote.Button.Arrow_Left:
                //    x -= increment;
                //    break;
                //case PS3Remote.Button.Arrow_Right:
                //    x += increment;
                //    break;
                case PS3Remote.Button.Enter:
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    return;
                case PS3Remote.Button.PopUp_Menu:
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
                    return;
            }
        }

        private void remote_Connected(object sender, EventArgs e)
        {
            if (DebugLog.isLogging) DebugLog.write("Remote connected");

            notifyIcon.Text = "PS3BluMote: Connected (Battery: " + remote.getBatteryLifeString() + ").";
            notifyIcon.Icon = Properties.Resources.Icon_Connected;
        }

        private void remote_Disconnected(object sender, EventArgs e)
        {
            if (DebugLog.isLogging) DebugLog.write("Remote disconnected");

            notifyIcon.Text = "PS3BluMote: Disconnected.";
            notifyIcon.Icon = Properties.Resources.Icon_Disconnected;
        }

        private void remote_Hibernated(object sender, EventArgs e)
        {
            if (DebugLog.isLogging) DebugLog.write("Remote Hibernated");

            notifyIcon.Text = "PS3BluMote: Hibernated (Battery: " + remote.getBatteryLifeString() + ").";
            notifyIcon.Icon = Properties.Resources.Icon_Hibernated;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.UserClosing) return;

            e.Cancel = true;

            this.Hide();
        }

        private void timerRepeat_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int y = 0;
            int x = 0;

            switch (lastButton)
            {
                case PS3Remote.Button.Arrow_Up:
                    y -= increment;
                    break;
                case PS3Remote.Button.Arrow_Down:
                    y += increment;
                    break;
                case PS3Remote.Button.Arrow_Left:
                    x -= increment;
                    break;
                case PS3Remote.Button.Arrow_Right:
                    x += increment;
                    break;
                //case PS3Remote.Button.Enter:
                //    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                //    return;
                //case PS3Remote.Button.PopUp_Menu:
                //    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                //    return;
            }

            if (x != 0 || y != 0)
            {
                //keyboard.sendKeysDown(mapping.keysMapped);
                //keyboard.releaseLastKeys();

                var position = MouseOperations.GetCursorPosition();
                position.X += x;
                position.Y += y;
                MouseOperations.SetCursorPosition(position);
            }
            //keyboard.sendKeysDown(keyboard.lastKeysDown);
            //keyboard.releaseLastKeys();
        }

        private void txtProductId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int i = int.Parse(txtProductId.Text.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void txtRepeatInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int i = int.Parse(txtRepeatInterval.Text);
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void txtVendorId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int i = int.Parse(txtVendorId.Text.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void buttonDump_Click(object sender, EventArgs e)
        {
            DebugLog.outputToFile(SETTINGS_DIRECTORY + "log.txt");
        }


        private void txtMinutes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = System.Convert.ToInt32(txtMinutes.Text) * 60 * 1000;
                if (remote != null) remote.hibernationInterval = i;
            }
            catch { }
        }

        private void comboBtAddr_TextChanged(object sender, EventArgs e)
        {
            if (comboBtAddr.Text.Length == 12 || comboBtAddr.Text.Length == 17)
            {
                cbHibernation.Enabled = true;
                if (remote != null) remote.btAddress = comboBtAddr.Text;
            }
            else if (comboBtAddr.Text == "Search" || comboBtAddr.Text == "Search again")
            {
                cbHibernation.Enabled = false;
                UpdateBtAddrList(500);
            }
            else cbHibernation.Enabled = false;
        }
        private void UpdateBtAddrList(int when)
        {
            comboBtAddr.Items.Clear();
            comboBtAddr.Text = "Searching";
            comboBtAddr.Enabled = false;
            timerFindBtAddress = new System.Timers.Timer(when);
            timerFindBtAddress.Elapsed += new System.Timers.ElapsedEventHandler(TimerFindBtAddress_Elapsed);
            timerFindBtAddress.AutoReset = false;
            timerFindBtAddress.Start();
        }

        private void comboBtAddr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
