using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace DatabaseConfigurationModule
{
    public class TableColumn
    {
        private readonly clsLocalConfig _localConfig;

        private clsTransaction transactionTableColumn;
        private clsRelationConfig relationConfigTableColumn;

        private clsDBLevel _dbLevelAttributes;
        private clsDBLevel _dbLevelRelations;
        private clsDBLevel _dbLevelColumn;

        private bool lockProperties;

        [Browsable(false)]
        public string GUID_FieldType
        {
            get { return _oRelFieldType != null ? _oRelFieldType.ID_Other : null; }
        }

        private long dimension;
        [Browsable(true)]
        public long Dimension
        {
            get { return _oAttDimension != null ? _oAttDimension.Val_Lng ?? 0 : 0; }
            set
            {
                transactionTableColumn.ClearItems();

                var saveOAtt = relationConfigTableColumn.Rel_ObjectAttribute(oItem_Column,
                    _localConfig.OItem_attributetype_dimensions, value);

                var result = transactionTableColumn.do_Transaction(saveOAtt, true);

                if (result.GUID == _localConfig.Globals.LState_Error.GUID)
                {
                    throw new Exception(result.GUID);
                }

                dimension = value;
            }
        }

        private bool nullable;
        [Browsable(true)]
        public bool Nullable
        {
            get { return _oAttNullable != null ? _oAttNullable.Val_Bit ?? false : false; }
            set
            {
                if (!lockProperties)
                {
                    transactionTableColumn.ClearItems();

                    var saveOAtt = relationConfigTableColumn.Rel_ObjectAttribute(oItem_Column,
                        _localConfig.OItem_attributetype_nullable, value);

                    var result = transactionTableColumn.do_Transaction(saveOAtt, true);

                    if (result.GUID == _localConfig.Globals.LState_Error.GUID)
                    {
                        throw new Exception(result.GUID);
                    }    
                }


                nullable = value;
            }
        }

        private bool unicode;
        [Browsable(true)]
        public bool Unicode
        {
            get { return _oAttUnicode != null ? _oAttUnicode.Val_Bit ?? false : false; }
            set
            {
                if (!lockProperties)
                {
                    transactionTableColumn.ClearItems();

                    var saveOAtt = relationConfigTableColumn.Rel_ObjectAttribute(oItem_Column,
                        _localConfig.OItem_attributetype_unicode, value);

                    var result = transactionTableColumn.do_Transaction(saveOAtt, true);

                    if (result.GUID == _localConfig.Globals.LState_Error.GUID)
                    {
                        throw new Exception(result.GUID);
                    }
                }
                unicode = value;
            }
        }

        private bool variable;
        [Browsable(true)]
        public bool Variable
        {
            get { return _oAttVariable != null ? _oAttVariable.Val_Bit ?? false : false; }
            set
            {
                if (!lockProperties)
                {
                    transactionTableColumn.ClearItems();

                    var saveOAtt = relationConfigTableColumn.Rel_ObjectAttribute(oItem_Column,
                        _localConfig.OItem_attributetype_variable, value);

                    var result = transactionTableColumn.do_Transaction(saveOAtt, true);

                    if (result.GUID == _localConfig.Globals.LState_Error.GUID)
                    {
                        throw new Exception(result.GUID);
                    }
                }
                variable = value;
            }
        }

        [Browsable(false)]
        public string NameColumn
        {
            get { return oItem_Column != null ? oItem_Column.Name : oItem_Column.Name; }
            set
            {
                if (!lockProperties)
                {
                    transactionTableColumn.ClearItems();

                    var result = transactionTableColumn.do_Transaction(oItem_Column);

                    if (result.GUID == _localConfig.Globals.LState_Error.GUID)
                    {
                        throw new Exception(result.GUID);
                    }
                }
                oItem_Column.Name = value;
            }
        }

        [Browsable(false)]
        public string NameFieldType 
        {
            get { return _oRelFieldType != null ? _oRelFieldType.Name_Other : null; }
        }

        public void SaveFieldType(clsOntologyItem oItem_FieldType)
        {
            transactionTableColumn.ClearItems();

            var saveFieldRelation = relationConfigTableColumn.Rel_ObjectRelation(oItem_Column, oItem_FieldType,
                _localConfig.OItem_relationtype_is_of_type);

            var result = transactionTableColumn.do_Transaction(saveFieldRelation,false);

            if (result.GUID == _localConfig.Globals.LState_Error.GUID)
            {
                throw new Exception(result.GUID);
            }

            _oRelFieldType = saveFieldRelation;
        }

        [Browsable(false)]
        public bool IsNew { get; private set; }

        private clsObjectAtt _oAttDimension;
        private clsObjectAtt _oAttNullable;
        private clsObjectAtt _oAttUnicode;
        private clsObjectAtt _oAttVariable;

        public clsOntologyItem oItem_Column;
        
        private clsObjectRel _oRelFieldType;

        [Browsable(false)]
        public bool IsCorrect
        {
            get
            {
                return _oRelFieldType != null;
            }
        }

        public void GetData()
        {
            lockProperties = true;
            var searchColumns = new List<clsOntologyItem>
            {
                new clsOntologyItem
                {
                    GUID = oItem_Column.GUID
                }
            };

            var result = _dbLevelColumn.get_Data_Objects(searchColumns);

            if (result.GUID == _localConfig.Globals.LState_Error.GUID || !_dbLevelColumn.OList_Objects.Any())
            {
                throw new Exception(result.GUID);
            }

            oItem_Column = _dbLevelColumn.OList_Objects.First();

            var searchAttributes = new List<clsObjectAtt>
            {
                new clsObjectAtt
                {
                    ID_AttributeType = _localConfig.OItem_attributetype_dimensions.GUID,
                    ID_Object = oItem_Column.GUID
                },
                new clsObjectAtt
                {
                    ID_AttributeType = _localConfig.OItem_attributetype_nullable.GUID,
                    ID_Object = oItem_Column.GUID
                },
                new clsObjectAtt
                {
                    ID_AttributeType = _localConfig.OItem_attributetype_unicode.GUID,
                    ID_Object = oItem_Column.GUID
                },
                new clsObjectAtt
                {
                    ID_AttributeType = _localConfig.OItem_attributetype_variable.GUID,
                    ID_Object = oItem_Column.GUID
                }
            };

            result = _dbLevelAttributes.get_Data_ObjectAtt(searchAttributes, boolIDs: false);

            if (result.GUID == _localConfig.Globals.LState_Error.GUID)
            {
                throw new Exception(result.GUID);
            }
            
            _oAttDimension =
                _dbLevelAttributes.OList_ObjectAtt.FirstOrDefault(col => col.ID_AttributeType == _localConfig.OItem_attributetype_dimensions.GUID);

            if (_oAttDimension != null)
            {
                Dimension = _oAttDimension.Val_Int ?? 0;
            }

            _oAttNullable =
                _dbLevelAttributes.OList_ObjectAtt.FirstOrDefault(col => col.ID_AttributeType == _localConfig.OItem_attributetype_nullable.GUID);

            if (_oAttNullable != null && _oAttNullable.Val_Bit != null)
            {
                Nullable = (bool)_oAttNullable.Val_Bit;
            }

            _oAttUnicode =
                _dbLevelAttributes.OList_ObjectAtt.FirstOrDefault(col => col.ID_AttributeType == _localConfig.OItem_attributetype_unicode.GUID);

            if (_oAttUnicode != null && _oAttUnicode.Val_Bit != null)
            {
                Unicode = (bool)_oAttUnicode.Val_Bit;
            }

            _oAttVariable =
                _dbLevelAttributes.OList_ObjectAtt.FirstOrDefault(col => col.ID_AttributeType == _localConfig.OItem_attributetype_variable.GUID);

            if (_oAttVariable != null && _oAttVariable.Val_Bit != null)
            {
                Variable = (bool)_oAttVariable.Val_Bit;
            }

            var searchFieldType = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = oItem_Column.GUID,
                    ID_RelationType = _localConfig.OItem_relationtype_is_of_type.GUID
                }
            };

            result = _dbLevelRelations.get_Data_ObjectRel(searchFieldType, boolIDs: false);

            if (result.GUID == _localConfig.Globals.LState_Error.GUID)
            {
                throw new Exception(result.GUID);
            }

            _oRelFieldType = _dbLevelRelations.OList_ObjectRel.FirstOrDefault();
            lockProperties = false;
        }

        public TableColumn(clsLocalConfig localConfig, string guid_Column, bool isNew)
        {
            _localConfig = localConfig;
            IsNew = isNew;
            oItem_Column = new clsOntologyItem
            {
                GUID = guid_Column
            };
            Initialize();


        }

        private void Initialize()
        {
            _dbLevelAttributes = new clsDBLevel(_localConfig.Globals);
            _dbLevelRelations = new clsDBLevel(_localConfig.Globals);
            _dbLevelColumn = new clsDBLevel(_localConfig.Globals);
            transactionTableColumn = new clsTransaction(_localConfig.Globals);
            relationConfigTableColumn = new clsRelationConfig(_localConfig.Globals);
            GetData();
        }
    }
}
