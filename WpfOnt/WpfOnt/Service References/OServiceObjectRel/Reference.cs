﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34011
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfOnt.OServiceObjectRel {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OServiceObjectRel.OServiceObjectRelSoap")]
    public interface OServiceObjectRelSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.Config[] Config();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.Config[]> ConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRels", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRels(bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRels", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsAsync(bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObject(string IdObject, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObject", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAsync(string IdObject, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdOther(string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdOtherAsync(string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationType(string IdObject, string IdRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationType", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAsync(string IdObject, string IdRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationTypeAndIdOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationTypeAndIdOther(string IdObject, string IdRelationType, string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationTypeAndIdOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAndIdOtherAsync(string IdObject, string IdRelationType, string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdRelationTypeAndIdOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdRelationTypeAndIdOther(string IdRelationType, string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdRelationTypeAndIdOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdRelationTypeAndIdOtherAsync(string IdRelationType, string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObject(string IdParentObject, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObject", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAsync(string IdParentObject, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentOther(string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentOtherAsync(string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationType(string IdParentObject, string IdRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationType", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAsync(string IdParentObject, string IdRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther(string IdParentObject, string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOtherAsync(string IdParentObject, string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdRelationTypeAndIdParentOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdRelationTypeAndIdParentOther(string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdRelationTypeAndIdParentOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdRelationTypeAndIdParentOtherAsync(string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther(string IdObject, string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOtherAsync(string IdObject, string IdRelationType, string IdParentOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther(string IdParentObject, string IdRelationType, string IdOther, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther", ReplyAction="*")]
        System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOtherAsync(string IdParentObject, string IdRelationType, string IdOther, bool onlyIds);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsObjectRel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iD_ObjectField;
        
        private string name_ObjectField;
        
        private string iD_Parent_ObjectField;
        
        private string name_Parent_ObjectField;
        
        private string iD_OtherField;
        
        private string name_OtherField;
        
        private string iD_Parent_OtherField;
        
        private string name_Parent_OtherField;
        
        private string iD_RelationTypeField;
        
        private string name_RelationTypeField;
        
        private string ontologyField;
        
        private string iD_DirectionField;
        
        private string name_DirectionField;
        
        private System.Nullable<long> orderIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ID_Object {
            get {
                return this.iD_ObjectField;
            }
            set {
                this.iD_ObjectField = value;
                this.RaisePropertyChanged("ID_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name_Object {
            get {
                return this.name_ObjectField;
            }
            set {
                this.name_ObjectField = value;
                this.RaisePropertyChanged("Name_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ID_Parent_Object {
            get {
                return this.iD_Parent_ObjectField;
            }
            set {
                this.iD_Parent_ObjectField = value;
                this.RaisePropertyChanged("ID_Parent_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Name_Parent_Object {
            get {
                return this.name_Parent_ObjectField;
            }
            set {
                this.name_Parent_ObjectField = value;
                this.RaisePropertyChanged("Name_Parent_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ID_Other {
            get {
                return this.iD_OtherField;
            }
            set {
                this.iD_OtherField = value;
                this.RaisePropertyChanged("ID_Other");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Name_Other {
            get {
                return this.name_OtherField;
            }
            set {
                this.name_OtherField = value;
                this.RaisePropertyChanged("Name_Other");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string ID_Parent_Other {
            get {
                return this.iD_Parent_OtherField;
            }
            set {
                this.iD_Parent_OtherField = value;
                this.RaisePropertyChanged("ID_Parent_Other");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Name_Parent_Other {
            get {
                return this.name_Parent_OtherField;
            }
            set {
                this.name_Parent_OtherField = value;
                this.RaisePropertyChanged("Name_Parent_Other");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string ID_RelationType {
            get {
                return this.iD_RelationTypeField;
            }
            set {
                this.iD_RelationTypeField = value;
                this.RaisePropertyChanged("ID_RelationType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Name_RelationType {
            get {
                return this.name_RelationTypeField;
            }
            set {
                this.name_RelationTypeField = value;
                this.RaisePropertyChanged("Name_RelationType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Ontology {
            get {
                return this.ontologyField;
            }
            set {
                this.ontologyField = value;
                this.RaisePropertyChanged("Ontology");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string ID_Direction {
            get {
                return this.iD_DirectionField;
            }
            set {
                this.iD_DirectionField = value;
                this.RaisePropertyChanged("ID_Direction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string Name_Direction {
            get {
                return this.name_DirectionField;
            }
            set {
                this.name_DirectionField = value;
                this.RaisePropertyChanged("Name_Direction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
        public System.Nullable<long> OrderID {
            get {
                return this.orderIDField;
            }
            set {
                this.orderIDField = value;
                this.RaisePropertyChanged("OrderID");
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
    public interface OServiceObjectRelSoapChannel : WpfOnt.OServiceObjectRel.OServiceObjectRelSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OServiceObjectRelSoapClient : System.ServiceModel.ClientBase<WpfOnt.OServiceObjectRel.OServiceObjectRelSoap>, WpfOnt.OServiceObjectRel.OServiceObjectRelSoap {
        
        public OServiceObjectRelSoapClient() {
        }
        
        public OServiceObjectRelSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OServiceObjectRelSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OServiceObjectRelSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OServiceObjectRelSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WpfOnt.OServiceObjectRel.Config[] Config() {
            return base.Channel.Config();
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.Config[]> ConfigAsync() {
            return base.Channel.ConfigAsync();
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRels(bool onlyIds) {
            return base.Channel.ObjectRels(onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsAsync(bool onlyIds) {
            return base.Channel.ObjectRelsAsync(onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObject(string IdObject, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObject(IdObject, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAsync(string IdObject, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAsync(IdObject, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdOther(string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdOther(IdOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdOtherAsync(string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdOtherAsync(IdOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationType(string IdObject, string IdRelationType, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationType(IdObject, IdRelationType, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAsync(string IdObject, string IdRelationType, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationTypeAsync(IdObject, IdRelationType, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationTypeAndIdOther(string IdObject, string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationTypeAndIdOther(IdObject, IdRelationType, IdOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAndIdOtherAsync(string IdObject, string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationTypeAndIdOtherAsync(IdObject, IdRelationType, IdOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdRelationTypeAndIdOther(string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdRelationTypeAndIdOther(IdRelationType, IdOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdRelationTypeAndIdOtherAsync(string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdRelationTypeAndIdOtherAsync(IdRelationType, IdOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObject(string IdParentObject, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObject(IdParentObject, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAsync(string IdParentObject, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAsync(IdParentObject, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentOther(string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentOther(IdParentOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentOtherAsync(string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentOtherAsync(IdParentOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationType(string IdParentObject, string IdRelationType, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationType(IdParentObject, IdRelationType, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAsync(string IdParentObject, string IdRelationType, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationTypeAsync(IdParentObject, IdRelationType, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther(string IdParentObject, string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther(IdParentObject, IdRelationType, IdParentOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOtherAsync(string IdParentObject, string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOtherAsync(IdParentObject, IdRelationType, IdParentOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdRelationTypeAndIdParentOther(string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdRelationTypeAndIdParentOther(IdRelationType, IdParentOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdRelationTypeAndIdParentOtherAsync(string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdRelationTypeAndIdParentOtherAsync(IdRelationType, IdParentOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther(string IdObject, string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther(IdObject, IdRelationType, IdParentOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOtherAsync(string IdObject, string IdRelationType, string IdParentOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOtherAsync(IdObject, IdRelationType, IdParentOther, onlyIds);
        }
        
        public WpfOnt.OServiceObjectRel.clsObjectRel[] ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther(string IdParentObject, string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther(IdParentObject, IdRelationType, IdOther, onlyIds);
        }
        
        public System.Threading.Tasks.Task<WpfOnt.OServiceObjectRel.clsObjectRel[]> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOtherAsync(string IdParentObject, string IdRelationType, string IdOther, bool onlyIds) {
            return base.Channel.ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOtherAsync(IdParentObject, IdRelationType, IdOther, onlyIds);
        }
    }
}
