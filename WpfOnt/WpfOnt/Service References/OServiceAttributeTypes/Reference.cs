﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfOnt.OServiceAttributeTypes {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OServiceAttributeTypes.OServiceAttributeTypesSoap")]
    public interface OServiceAttributeTypesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceAttributeTypes.Config[] Config();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.Config[]> ConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypes", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeGuid(string guidAttributeType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeGuid", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeGuidAsync(string guidAttributeType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeName(string nameAttributeType, bool strict, bool caseSensitive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeName", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeNameAsync(string nameAttributeType, bool strict, bool caseSensitive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeIdDataType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeIdDataType(string idDataType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AttributeTypesByAttributeTypeIdDataType", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeIdDataTypeAsync(string idDataType);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Config : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string configItemField;
        
        private string configValueStringField;
        
        private int configValueIntField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ConfigItem {
            get {
                return this.configItemField;
            }
            set {
                this.configItemField = value;
                this.RaisePropertyChanged("ConfigItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ConfigValueString {
            get {
                return this.configValueStringField;
            }
            set {
                this.configValueStringField = value;
                this.RaisePropertyChanged("ConfigValueString");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int ConfigValueInt {
            get {
                return this.configValueIntField;
            }
            set {
                this.configValueIntField = value;
                this.RaisePropertyChanged("ConfigValueInt");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsOntologyItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsOntologyItem[] oList_RelField;
        
        private string gUIDField;
        
        private string gUID_ParentField;
        
        private string gUID_RelatedField;
        
        private string gUID_RelationField;
        
        private string nameField;
        
        private string captionField;
        
        private string additional1Field;
        
        private string additional2Field;
        
        private string typeField;
        
        private string filterField;
        
        private System.Nullable<int> imageIDField;
        
        private System.Nullable<int> versionField;
        
        private System.Nullable<long> levelField;
        
        private System.Nullable<bool> new_ItemField;
        
        private System.Nullable<bool> deletedField;
        
        private System.Nullable<bool> markField;
        
        private System.Nullable<bool> objectReferenceField;
        
        private System.Nullable<int> directionField;
        
        private System.Nullable<long> minField;
        
        private System.Nullable<long> max1Field;
        
        private System.Nullable<long> max2Field;
        
        private System.Nullable<long> val_LongField;
        
        private System.Nullable<bool> val_BoolField;
        
        private System.Nullable<System.DateTime> val_DateField;
        
        private System.Nullable<double> val_RealField;
        
        private string val_StringField;
        
        private System.Nullable<long> countField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public clsOntologyItem[] OList_Rel {
            get {
                return this.oList_RelField;
            }
            set {
                this.oList_RelField = value;
                this.RaisePropertyChanged("OList_Rel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string GUID {
            get {
                return this.gUIDField;
            }
            set {
                this.gUIDField = value;
                this.RaisePropertyChanged("GUID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string GUID_Parent {
            get {
                return this.gUID_ParentField;
            }
            set {
                this.gUID_ParentField = value;
                this.RaisePropertyChanged("GUID_Parent");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GUID_Related {
            get {
                return this.gUID_RelatedField;
            }
            set {
                this.gUID_RelatedField = value;
                this.RaisePropertyChanged("GUID_Related");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string GUID_Relation {
            get {
                return this.gUID_RelationField;
            }
            set {
                this.gUID_RelationField = value;
                this.RaisePropertyChanged("GUID_Relation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Caption {
            get {
                return this.captionField;
            }
            set {
                this.captionField = value;
                this.RaisePropertyChanged("Caption");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Additional1 {
            get {
                return this.additional1Field;
            }
            set {
                this.additional1Field = value;
                this.RaisePropertyChanged("Additional1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Additional2 {
            get {
                return this.additional2Field;
            }
            set {
                this.additional2Field = value;
                this.RaisePropertyChanged("Additional2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Filter {
            get {
                return this.filterField;
            }
            set {
                this.filterField = value;
                this.RaisePropertyChanged("Filter");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public System.Nullable<int> ImageID {
            get {
                return this.imageIDField;
            }
            set {
                this.imageIDField = value;
                this.RaisePropertyChanged("ImageID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public System.Nullable<int> Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("Version");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
        public System.Nullable<long> Level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
                this.RaisePropertyChanged("Level");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=14)]
        public System.Nullable<bool> New_Item {
            get {
                return this.new_ItemField;
            }
            set {
                this.new_ItemField = value;
                this.RaisePropertyChanged("New_Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=15)]
        public System.Nullable<bool> Deleted {
            get {
                return this.deletedField;
            }
            set {
                this.deletedField = value;
                this.RaisePropertyChanged("Deleted");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=16)]
        public System.Nullable<bool> Mark {
            get {
                return this.markField;
            }
            set {
                this.markField = value;
                this.RaisePropertyChanged("Mark");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=17)]
        public System.Nullable<bool> ObjectReference {
            get {
                return this.objectReferenceField;
            }
            set {
                this.objectReferenceField = value;
                this.RaisePropertyChanged("ObjectReference");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=18)]
        public System.Nullable<int> Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
                this.RaisePropertyChanged("Direction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=19)]
        public System.Nullable<long> Min {
            get {
                return this.minField;
            }
            set {
                this.minField = value;
                this.RaisePropertyChanged("Min");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=20)]
        public System.Nullable<long> Max1 {
            get {
                return this.max1Field;
            }
            set {
                this.max1Field = value;
                this.RaisePropertyChanged("Max1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=21)]
        public System.Nullable<long> Max2 {
            get {
                return this.max2Field;
            }
            set {
                this.max2Field = value;
                this.RaisePropertyChanged("Max2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=22)]
        public System.Nullable<long> Val_Long {
            get {
                return this.val_LongField;
            }
            set {
                this.val_LongField = value;
                this.RaisePropertyChanged("Val_Long");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=23)]
        public System.Nullable<bool> Val_Bool {
            get {
                return this.val_BoolField;
            }
            set {
                this.val_BoolField = value;
                this.RaisePropertyChanged("Val_Bool");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=24)]
        public System.Nullable<System.DateTime> Val_Date {
            get {
                return this.val_DateField;
            }
            set {
                this.val_DateField = value;
                this.RaisePropertyChanged("Val_Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=25)]
        public System.Nullable<double> Val_Real {
            get {
                return this.val_RealField;
            }
            set {
                this.val_RealField = value;
                this.RaisePropertyChanged("Val_Real");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Val_String {
            get {
                return this.val_StringField;
            }
            set {
                this.val_StringField = value;
                this.RaisePropertyChanged("Val_String");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=27)]
        public System.Nullable<long> Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
                this.RaisePropertyChanged("Count");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OServiceAttributeTypesSoapChannel : WpfOnt.OServiceAttributeTypes.OServiceAttributeTypesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OServiceAttributeTypesSoapClient : System.ServiceModel.ClientBase<WpfOnt.OServiceAttributeTypes.OServiceAttributeTypesSoap>, WpfOnt.OServiceAttributeTypes.OServiceAttributeTypesSoap {
        
        public OServiceAttributeTypesSoapClient() {
        }
        
        public OServiceAttributeTypesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OServiceAttributeTypesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OServiceAttributeTypesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OServiceAttributeTypesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WpfOnt.OServiceAttributeTypes.Config[] Config() {
            return base.Channel.Config();
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.Config[]> ConfigAsync() {
            return base.Channel.ConfigAsync();
        }
        
        public WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypes() {
            return base.Channel.AttributeTypes();
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesAsync() {
            return base.Channel.AttributeTypesAsync();
        }
        
        public WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeGuid(string guidAttributeType) {
            return base.Channel.AttributeTypesByAttributeTypeGuid(guidAttributeType);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeGuidAsync(string guidAttributeType) {
            return base.Channel.AttributeTypesByAttributeTypeGuidAsync(guidAttributeType);
        }
        
        public WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeName(string nameAttributeType, bool strict, bool caseSensitive) {
            return base.Channel.AttributeTypesByAttributeTypeName(nameAttributeType, strict, caseSensitive);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeNameAsync(string nameAttributeType, bool strict, bool caseSensitive) {
            return base.Channel.AttributeTypesByAttributeTypeNameAsync(nameAttributeType, strict, caseSensitive);
        }
        
        public WpfOnt.OServiceAttributeTypes.clsOntologyItem[] AttributeTypesByAttributeTypeIdDataType(string idDataType) {
            return base.Channel.AttributeTypesByAttributeTypeIdDataType(idDataType);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceAttributeTypes.clsOntologyItem[]> AttributeTypesByAttributeTypeIdDataTypeAsync(string idDataType) {
            return base.Channel.AttributeTypesByAttributeTypeIdDataTypeAsync(idDataType);
        }
    }
}
