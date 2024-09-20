namespace Net.MyStuff.BizSocket;

using System;
using System.Drawing;
using System.Windows.Forms;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;

[ExternalTool("BizSocket")]
public sealed class BizSocketForm : ToolFormBase, IExternalToolForm
{
    public ApiContainer? _maybeAPIContainer { get; set; }
    private ApiContainer APIs => _maybeAPIContainer!;

    private readonly Label testLabel = new Label { AutoSize = true, Text = "Test Label" };
    private readonly Label romName = new Label { AutoSize = true, Text = "No ROM Loaded", Location = new Point(5, 100) };
    private TcpSocketClient socketClient;

    protected override string WindowTitleStatic => "BizSocket";

    public BizSocketForm()
    {
        ClientSize = new Size(480, 320);
        SuspendLayout();
        Controls.Add(testLabel);
        Controls.Add(romName);
        ResumeLayout(performLayout: false);
        PerformLayout();

        socketClient = new TcpSocketClient();
        socketClient.MessageReceived += SocketClient_MessageReceived;
    }

    private void SocketClient_MessageReceived(object sender, string message)
    {
        testLabel.Invoke(new Action(() => testLabel.Text = message));
    }

    public override void Restart()
    {
        romName.Text = APIs.Emulation.GetGameInfo()?.Name == "Null" ? "No ROM Loaded" : APIs.Emulation.GetGameInfo()?.Name;
    }

    protected override void UpdateAfter()
    {
        socketClient.SendMessage("Current frame: " + APIs.Emulation.FrameCount().ToString());
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            socketClient.Disconnect();
        }
        base.Dispose(disposing);
    }
}