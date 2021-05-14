using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractDinerView
{
    public partial class FormImplementer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        
        public int Id { set { id = value; } }

        private readonly ImplementerLogic logic;

        private int? id;
        public FormImplementer(ImplementerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text) || string.IsNullOrEmpty(textBoxTimeToWork.Text) ||
                string.IsNullOrEmpty(textBoxTimeToRest.Text))
            {
                MessageBox.Show("Не все поля заполнены. Заполните их", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ImplementerBindingModel
                {
                    Id = id,
                    ImplementerFIO = textBoxFIO.Text,
                    WorkingTime = Convert.ToInt32(textBoxTimeToWork.Text),
                    PauseTime = Convert.ToInt32(textBoxTimeToRest.Text),
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
