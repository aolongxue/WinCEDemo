using System;
using System.Windows.Forms;
using JsonHelper;
using InvokeDLL;

namespace WinCEPage
{
    public partial class InvokeForm : Form
    {
        public InvokeForm()
        {
            InitializeComponent();
        }

        // URL
        // string url = "http://222.66.83.59/c2m2/api/NativeInvokeAPI/GetOrderAmount";
        string url = "http://192.168.15.31:8090/Fabric/GetFabricDetail";

        // ����
        private void btnInvoke_Click(object sender, EventArgs e)
        {
            // ��ֵ
            InvokeEntity entity = new InvokeEntity();
            entity.FabricId = txtInput.Text;
            // entity.Code = "T201508180000039630";

            // ���л���JSON
            string json = Converter.Serialize(entity);

            // ��ֵ
            InvokeWebAPI invoke = new InvokeWebAPI();
            string msg = invoke.CreatePostHttpResponse(url, json);

            // ���շ���ֵ�󶨵�ҳ��
            lblMessage.Text = msg;
        }
    }
}