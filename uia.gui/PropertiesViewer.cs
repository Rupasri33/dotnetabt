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
        private IUIItem m_Object;

        /// <summary>
        /// constructor
        /// </summary>
        public PropertiesViewer()
        {
            InitializeComponent();
            CurrentName = null;
        }

        /// <summary>
        /// event - current "Object" is not valid any more
        /// </summary>
        public event InvalidItemHandler InvalidItemSelected;

        /// <summary>
        /// current Object's name
        /// </summary>
        public string CurrentName { get; set; }

        /// <summary>
        /// current ActionManager - used to match controls
        /// </summary>
        public UIAActionManager ActionManager { get; set; }

        /// <summary>
        /// current Interface used for matching
        /// </summary>
        public IInterface CurrentInterface { get; set; }

        /// <summary>
        /// the Object to show properties, it may be a window, or a control
        /// </summary>
        public IUIItem Object
        {
            get { return m_Object; }
            set
            {
                m_Object = value;
                Reset();

                if (m_Object != null)
                {
                    if (ShowProperties() == false)
                    {
                        Reset();

                        // if cannot show property, we consider the Object is invalid
                        if (InvalidItemSelected != null)
                            InvalidItemSelected();
                    }
                }
            }
        }

        /// <summary>
        /// reset the property list
        /// </summary>
        public void Reset()
        {
            listView.Items.Clear();
        }

        /// <summary>
        /// show properties of an item - use Reflection technology
        /// </summary>
        /// <returns></returns>
        private bool ShowProperties()
        {
            AutomationElement.AutomationElementInformation source = Object.AutomationElement.Current;

            // get all property methods of Object - use Reflection
            PropertyInfo [] properties = source.GetType().GetProperties();
            bool ret = true;

            try
            {
                // currently stop updating the list
                listView.BeginUpdate();

                // loop for each property
                foreach (PropertyInfo prop in properties)
                {
                    // get property name and value
                    string strName = prop.Name;
                    object strVal = prop.GetValue(source);

                    // create a corresponding item in the list
                    if (strVal != null)
                    {
                        ListViewItem item = new ListViewItem(strName);
                        item.SubItems.Add(strVal.ToString());

                        // if current Object was matched, show the property which are chosen for 'criteria'
                        if (CurrentInterface != null && CurrentName != null &&
                            CurrentInterface.Controls.ContainsKey(CurrentName) &&
                            CurrentInterface.Controls[CurrentName].ContainsKey(strName.ToLower()))
                        {
                            item.Checked = true;
                            item.Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                            listView.Items.Insert(0, item);
                        }
                        else // just show the property
                            listView.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                // some error occured, we cannot show the properties, so the Object is considered as invalid
                ret = false;
            }
            finally
            {
                // resume updating the list
                listView.EndUpdate();
            }

            return ret;
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (CurrentInterface != null && CurrentName != null)
            {
                if (e.Item.Checked)
                    CurrentInterface.Controls[CurrentName][e.Item.Text.ToLower()] = e.Item.SubItems[1].Text;
                else
                    CurrentInterface.Controls[CurrentName].Remove(e.Item.Text.ToLower());
            }
        }
    }
}
