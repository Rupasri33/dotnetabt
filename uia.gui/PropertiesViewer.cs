using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TestStack.White.UIItems;
using System.Reflection;
using System.Windows.Automation;

using abt.model;
using uia_auto.auto;

namespace uia_gui.components
{
    public delegate void InvalidItemHandler();

    public partial class PropertiesViewer : UserControl
    {
        public PropertiesViewer()
        {
            InitializeComponent();
        }

        public event InvalidItemHandler InvalidItemSelected;

        public string CurrentName { get; set; }
        public UIAActionManager ActionManager { get; set; }
        public IInterface CurrentInterface { get; set; }

        private IUIItem m_Object;
        public IUIItem Object
        {
            get { return m_Object; }
            set
            {
                m_Object = value;
                listView.Items.Clear();

                if (m_Object != null)
                {
                    if (ShowProperties() == false)
                    {
                        if (InvalidItemSelected != null)
                            InvalidItemSelected();
                    }
                }
            }
        }

        public void Reset()
        {
            listView.Items.Clear();
        }

        private bool ShowProperties()
        {
            AutomationElement.AutomationElementInformation source = Object.AutomationElement.Current;
            PropertyInfo [] properties = source.GetType().GetProperties();
            bool ret = true;

            try
            {
                listView.BeginUpdate();
                foreach (PropertyInfo prop in properties)
                {
                    string strName = prop.Name;
                    object strVal = prop.GetValue(source);

                    ListViewItem item = new ListViewItem(strName);
                    item.SubItems.Add(strVal != null ? strVal.ToString() : @"{null}");

                    if (CurrentInterface != null && CurrentName != null)
                    {
                        if (CurrentInterface.Controls.ContainsKey(CurrentName) &&
                            CurrentInterface.Controls[CurrentName].ContainsKey(strName.ToLower()))
                        {
                            item.Checked = true;
                            item.Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                            listView.Items.Insert(0, item);
                        }
                        else
                            listView.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                listView.EndUpdate();
            }
            return ret;
        }
    }
}
