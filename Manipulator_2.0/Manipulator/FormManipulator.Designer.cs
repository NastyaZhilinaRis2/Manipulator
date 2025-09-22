
namespace Manipulator
{
    partial class FormManipulator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainContainer = new SplitContainer();
            trackBarRotation2 = new TrackBar();
            trackBarExtendable2 = new TrackBar();
            trackBarRotation = new TrackBar();
            trackBarExtendable = new TrackBar();
            trackBarWheels = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)MainContainer).BeginInit();
            MainContainer.Panel1.SuspendLayout();
            MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarRotation2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarExtendable2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarRotation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarExtendable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWheels).BeginInit();
            SuspendLayout();
            // 
            // MainContainer
            // 
            MainContainer.Dock = DockStyle.Fill;
            MainContainer.FixedPanel = FixedPanel.Panel1;
            MainContainer.Location = new Point(50, 50);
            MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            MainContainer.Panel1.Controls.Add(trackBarRotation2);
            MainContainer.Panel1.Controls.Add(trackBarExtendable2);
            MainContainer.Panel1.Controls.Add(trackBarRotation);
            MainContainer.Panel1.Controls.Add(trackBarExtendable);
            MainContainer.Panel1.Controls.Add(trackBarWheels);
            // 
            // MainContainer.Panel2
            // 
            MainContainer.Panel2.BackColor = SystemColors.ButtonShadow;
            MainContainer.Panel2.Paint += MainContainer_Panel2_Paint;
            MainContainer.Size = new Size(700, 350);
            MainContainer.SplitterDistance = 189;
            MainContainer.TabIndex = 1;
            // 
            // trackBarRotation2
            // 
            trackBarRotation2.Location = new Point(3, 156);
            trackBarRotation2.Maximum = 360;
            trackBarRotation2.Name = "trackBarRotation2";
            trackBarRotation2.Size = new Size(179, 45);
            trackBarRotation2.TabIndex = 4;
            trackBarRotation2.TickStyle = TickStyle.None;
            trackBarRotation2.Scroll += trackBarRotation2_Scroll;
            // 
            // trackBarExtendable2
            // 
            trackBarExtendable2.Location = new Point(3, 207);
            trackBarExtendable2.Maximum = 2;
            trackBarExtendable2.Name = "trackBarExtendable2";
            trackBarExtendable2.Size = new Size(179, 45);
            trackBarExtendable2.TabIndex = 3;
            trackBarExtendable2.TickStyle = TickStyle.None;
            trackBarExtendable2.Scroll += trackBarExtendable2_Scroll;
            // 
            // trackBarRotation
            // 
            trackBarRotation.Location = new Point(3, 105);
            trackBarRotation.Maximum = 360;
            trackBarRotation.Name = "trackBarRotation";
            trackBarRotation.Size = new Size(179, 45);
            trackBarRotation.TabIndex = 2;
            trackBarRotation.TickStyle = TickStyle.None;
            trackBarRotation.Scroll += trackBarRotation_Scroll;
            // 
            // trackBarExtendable
            // 
            trackBarExtendable.Location = new Point(3, 54);
            trackBarExtendable.Maximum = 2;
            trackBarExtendable.Name = "trackBarExtendable";
            trackBarExtendable.Size = new Size(179, 45);
            trackBarExtendable.TabIndex = 1;
            trackBarExtendable.TickStyle = TickStyle.None;
            trackBarExtendable.Scroll += trackBarExtendable_Scroll;
            // 
            // trackBarWheels
            // 
            trackBarWheels.Location = new Point(3, 3);
            trackBarWheels.Maximum = 40;
            trackBarWheels.Name = "trackBarWheels";
            trackBarWheels.Size = new Size(179, 45);
            trackBarWheels.TabIndex = 0;
            trackBarWheels.TickStyle = TickStyle.None;
            trackBarWheels.Scroll += trackBarWheels_Scroll;
            // 
            // FormManipulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainContainer);
            MaximizeBox = false;
            Name = "FormManipulator";
            Padding = new Padding(50);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Манипулятор";
            MainContainer.Panel1.ResumeLayout(false);
            MainContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainContainer).EndInit();
            MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarRotation2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarExtendable2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarRotation).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarExtendable).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarWheels).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private SplitContainer MainContainer;
        private TrackBar trackBarRotation2;
        private TrackBar trackBarExtendable2;
        private TrackBar trackBarRotation;
        private TrackBar trackBarExtendable;
        private TrackBar trackBarWheels;
    }
}
