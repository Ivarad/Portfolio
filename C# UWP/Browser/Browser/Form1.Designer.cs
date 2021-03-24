using System.Windows.Forms;

namespace Browser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {

            this.Panel = new System.Windows.Forms.TableLayoutPanel() { AutoSize = true, RowCount = 3, ColumnCount = 80, Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom, Dock = System.Windows.Forms.DockStyle.Fill };

            this.Menu = new System.Windows.Forms.MenuStrip();

            this.Tab = new System.Windows.Forms.TabControl() { Dock = DockStyle.Fill };

            this.MenuTasks = new System.Windows.Forms.ToolStripMenuItem("Task");

            this.Addres = new System.Windows.Forms.TextBox() { Dock = DockStyle.Fill };

            this.Menu.Items.Add(this.MenuTasks);

            this.Panel.Controls.Add(this.Menu, 0, 0);
            this.Panel.SetColumnSpan(this.Menu, 80);

            //Ну вот никак, ну никак панель не влияет на добавление вкладок. У меня она поделена аж на 80 колонок. У тебя во много раз меньше. Но у меня то не пидорасит) Я маг што ле?!)) может быть
            //Не, я думаю, у тебя просто там куча текста конструктора, и я думаю, что из-за него происходит путанница. Тут ты просто чотко и ясно видишь чо я делаю как зачем и почему. А вот у тебя там можно натурально запутаться. Распутаться бы. Мне даже кажестся, что тебе ща проще надстройку над этим примером свою сделать, чтоб под себя и все. Ну да, но я пока буду свой старый ковырять. Ну ок, пошли туда.

            this.Panel.Controls.Add(this.Addres, 0, 1);
            this.Panel.SetColumnSpan(this.Addres, 80);

            this.Panel.Controls.Add(this.Tab, 0, 2);
            this.Panel.SetColumnSpan(this.Tab, 80);

            Add_Tabs();

            this.MenuTasks.DropDownItems.Add("Add Tab");

            this.MenuTasks.DropDownItems[0].Click += MenuTasks_AddTab_Click;

            this.Addres.KeyDown += Addres_KeyDown;

            this.components = new System.ComponentModel.Container();
            this.Text = "Browser";
            this.AutoSize = true;
            this.Controls.Add(this.Panel);
        }

        private void Addres_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                (this.Tab.SelectedTab.Controls[0] as WebBrowser).Navigate(this.Addres.Text);

                //При тебе прям написал) Ты что такой лютый. Причем тут панелька, в добавлении вкладок?) Это кажись ты чо то с разметкой намутил. Ок добавим еще столбцов.
            }
        }

        private void MenuTasks_AddTab_Click(object sender, System.EventArgs e)
        {
            Add_Tabs();
        }

        private void Add_Tabs()
        {
            TabPage tab = new TabPage("New page");
            WebBrowser web = new WebBrowser();
            web.Dock = DockStyle.Fill;
            tab.Controls.Add(web);

            web.Navigate("https://www.yandex.ru");

            this.Tab.TabPages.Add(tab);
            this.Addres.Text = "https://yandex.ru";
        }

        private System.Windows.Forms.TableLayoutPanel Panel;

        private System.Windows.Forms.TabControl Tab;

        private System.Windows.Forms.TextBox Addres;

        private System.Windows.Forms.MenuStrip Menu;

        private System.Windows.Forms.ToolStripMenuItem MenuTasks;

        #endregion
    }
}

