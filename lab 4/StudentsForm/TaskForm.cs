using System.Reflection;
using StudentModel;
namespace StudentsForm
{
    public partial class TaskForm : Form
    {
        Assembly assembly;
        IEnumerable<Type> types;

        Type currentType;
        object currentObject;

        MethodInfo currentMethod;
        object[]? methodParameters;

        public TaskForm()
        {
            InitializeComponent();
        }

        private void methodParamList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            assembly = Assembly.Load("StudentModel");

            types = assembly.GetTypes()
                .Where(t => !t.IsAbstract && t.GetInterface("IEnrollee") != null);

            methodList.Enabled = false;
            createObjectButton.Enabled = false;
            enterMethodParamButton.Enabled = false;
            doMethodButton.Enabled = false;

            classList.Items.AddRange(types.Select(t =>
            t.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText
            ).ToArray());
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            doMethodButton.Enabled = true;
            enterMethodParamButton.Enabled = true;

            MessageBox.Show($"Введите объект класса" +
                $" {currentType.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText}");

            object newObject = Activator.CreateInstance(currentType);


            var form = new Form();
            form.ClientSize = new Size(300, 200);
            int y = 0;
            foreach (var it in newObject.GetType().GetProperties())
            {
                var attribute = it.GetCustomAttributes(true).OfType<LabelAttribute>().First();
                var label = new Label { Top = y, Left = 0, Width = form.ClientSize.Width / 2, Height = 16 };
                label.Text = attribute.LabelText;

                var textBox = new TextBox { Top = y, Left = label.Width, Width = label.Width, Height = 16 };
                textBox.Text = it.GetValue(newObject).ToString();

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                y += label.Height + 5;
            }

            form.Controls.Add(new Button() { Top = 150, Left = 170, Width = 100, Height = 50, Text = "Ок" });
            form.Controls[form.Controls.Count - 1].Click
                += new EventHandler((object sender, EventArgs e) =>
                {
                    form.DialogResult = DialogResult.OK;
                    form.Hide();
                });


            if (form.ShowDialog() == DialogResult.OK)
            {
                var props = newObject.GetType().GetProperties();
                for (int i = 1, j = 0; i < form.Controls.Count; i += 2, j++)
                {
                    var a = form.Controls[i].Text;
                    if (props[j].PropertyType.Name == "Int32")
                    {
                        props[j].SetValue(newObject, Int32.Parse(a));
                    }
                    else
                    {
                        props[j].SetValue(newObject, a);
                    }
                }
            }

            currentObject = newObject;
            ShowProperties();
        }

        private void classList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentType = types.First(t =>
            t.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText
            == classList.SelectedItem.ToString());

            methodList.Enabled = true;
            createObjectButton.Enabled = true;
            IEnumerable<string> objectMethods = (new object()).GetType()
               .GetMethods().Select(method => method.Name);

            methodList.Items.Clear();

            methodList.Items.AddRange(currentType.GetMethods()
                .Where(m => !objectMethods.Contains(m.Name)
                && m.Name.Substring(0, 4) != "get_"
                && m.Name.Substring(0, 4) != "set_")
                .Select(t =>
            t.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText
            ).ToArray());
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<string> objectMethods = (new object()).GetType()
               .GetMethods().Select(method => method.Name);



            currentMethod = currentType.GetMethods()
                .First(
                m => !objectMethods.Contains(m.Name)
                && m.Name.Substring(0, 4) != "get_"
                && m.Name.Substring(0, 4) != "set_"
                && m.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText
                                            == methodList.SelectedItem.ToString());


            if (currentMethod.GetParameters().Length == 0)
            {
                methodParameters = null;
                enterMethodParamButton.Enabled = false;
            }
            else
            {
                enterMethodParamButton.Enabled = true;
            }
                   

        }

        private void enterMethodParamButton_Click(object sender, EventArgs e)
        {
            if (methodList.SelectedIndex != -1)
            {
                methodParamList.Items.Clear();
                if (currentMethod.GetParameters().Length != 0)
                {
                    var form = new Form();
                    form.ClientSize = new Size(300, 200);
                    int y = 0;
                    foreach (var it in currentMethod.GetParameters())
                    {
                        var attribute = it.ToString();
                        var label = new Label { Top = y, Left = 0, Width = form.ClientSize.Width / 2, Height = 16 };
                        label.Text = attribute;

                        var textBox = new TextBox { Top = y, Left = label.Width, Width = label.Width, Height = 16 };
                        textBox.Text = "0";

                        form.Controls.Add(label);
                        form.Controls.Add(textBox);
                        y += label.Height + 5;
                    }

                    form.Controls.Add(new Button() { Top = 150, Left = 170, Width = 100, Height = 50, Text = "Ок" });
                    form.Controls[form.Controls.Count - 1].Click
                        += new EventHandler((object sender, EventArgs e) =>
                        {
                            form.DialogResult = DialogResult.OK;
                            form.Hide();
                        });
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var listParam = new List<object>();
                        for (int i = 1; i < form.Controls.Count - 1; i += 2)
                        {
                            var a = form.Controls[i].Text;
                            listParam.Add(int.Parse(a));
                            methodParamList.Items.Add(form.Controls[i - 1].Text + ": " + a);
                        }
                        methodParameters = listParam.Select(x => x).ToArray();
                        doMethodButton.Enabled = true;
                    }
                }
                else
                {
                    methodParameters = null;
                }
            }
        }

        private void doMethodButton_Click(object sender, EventArgs e)
        {
            if (methodList.SelectedIndex != -1)
            {
                if (currentMethod.GetParameters().Length != 0 && methodParameters == null)
                {
                    MessageBox.Show("Сначала введите параметры метода!");
                }
                else
                {
                    if (currentMethod.ReturnType == typeof(void))
                    {
                        currentMethod.Invoke(currentObject, methodParameters);
                        MessageBox.Show("Метод выполнен");
                    }
                    else
                    {
                        MessageBox.Show(currentMethod.Invoke(currentObject, methodParameters).ToString());
                    }

                    ShowProperties();
                }
            }
            else
            {
                MessageBox.Show("Создайте объект и выберите метод");
            }
        }

        private void ShowProperties()
        {
            propertyList.Items.Clear();
            foreach (var item in currentType.GetProperties())
            {
                propertyList.Items.Add(item.GetCustomAttributes(true).OfType<LabelAttribute>().First().LabelText
                    + ": " + item.GetValue(currentObject));
            }
        }
    }
}