using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.BusinessLogic;
using AbstractDinerBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractDinerView
{
    public partial class FormSnack : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        
        public int Id { set { id = value; } }
        
        private readonly SnackLogic logic;
        
        private int? id;
        
        private Dictionary<int, (string, int)> SnackComponents;

        public FormSnack(SnackLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormSnack_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SnackViewModel view = logic.Read(new SnackBindingModel {Id = id.Value})?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SnackName;
                        textBoxPrice.Text = view.Price.ToString();
                        SnackComponents = view.SnackComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SnackComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (SnackComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in SnackComponents)
                    {
                        dataGridView.Rows.Add(new object[] {  pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSnackComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (SnackComponents.ContainsKey(form.Id))
                {
                    SnackComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    SnackComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        SnackComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (SnackComponents == null || SnackComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new SnackBindingModel
                {
                    Id = id,
                    SnackName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    SnackComponents = SnackComponents
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
