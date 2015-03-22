using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace DatabaseConfigurationModule
{
    public partial class UserControl_Column : UserControl
    {
        private clsLocalConfig _localConfig;

        private clsDBLevel _dbLevelFieldTypes;

        private TableColumn tableColumn;

        public bool LockItems;

        public UserControl_Column(clsLocalConfig localConfig)
        {
            _localConfig = localConfig;
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            _dbLevelFieldTypes = new clsDBLevel(_localConfig.Globals);
            GetFieldTypes();
        }

        private clsOntologyItem GetFieldTypes()
        {
            var searchFieldTypes = new List<clsOntologyItem>
            {
                new clsOntologyItem
                {
                    GUID_Parent = _localConfig.OItem_class_field_type.GUID
                }
            };

            var result = _dbLevelFieldTypes.get_Data_Objects(searchFieldTypes);

            if (result.GUID == _localConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Beim Ermitteln der Daten ist ein Fehler unterlaufen!", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result.GUID == _localConfig.Globals.LState_Success.GUID)
            {
                comboBox_FieldType.DataSource =
                    _dbLevelFieldTypes.OList_Objects.OrderBy(fieldType => fieldType.Name).ToList();
                comboBox_FieldType.ValueMember = "GUID";
                comboBox_FieldType.DisplayMember = "Name";
            }
            return result;
        }

        public void Initialize(clsOntologyItem oItem_Column)
        {
            try
            {
                tableColumn = new TableColumn(_localConfig, oItem_Column.GUID, (oItem_Column.Mark != null ? (bool)oItem_Column.Mark : false));

                LockItems = true;

                if (tableColumn.GUID_FieldType != null)
                {
                    comboBox_FieldType.SelectedValue = tableColumn.GUID_FieldType;
                }

                propertyGrid_Attributes.SelectedObject = tableColumn;

            }
            catch (Exception)
            {
                MessageBox.Show(this, "Beim Ermitteln der Daten ist ein Fehler unterlaufen!", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClearItems()
        {
            
        }
    }
}
