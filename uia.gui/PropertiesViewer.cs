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

        private UIItem m_Object;
        public UIItem Object
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

        private bool ShowProperties()
        {
            AutomationElement.AutomationElementInformation source = Object.AutomationElement.Current;
            PropertyInfo [] properties = source.GetType().GetProperties();
            bool ret = true;

            listView.BeginUpdate();
            try
            {
                foreach (PropertyInfo prop in properties)
                {
                    string strName = prop.Name;
                    object strVal = prop.GetValue(source);

                    ListViewItem item = listView.Items.Add(strName);
                    item.SubItems.Add(strVal != null ? strVal.ToString() : @"{null}");

                    if (CurrentInterface != null && CurrentName != null)
                    {
                        if (CurrentInterface.Controls.ContainsKey(CurrentName) &&
                            CurrentInterface.Controls[CurrentName].ContainsKey(strName.ToLower()))
                            item.Checked = true;
                    }
                }
            }
            catch (Exception)
            {
                ret = false;
            }

            listView.EndUpdate();
            return ret;
        }
    }
}
