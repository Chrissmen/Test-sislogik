﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_sislogik.WS_LoggerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Log", Namespace="http://schemas.datacontract.org/2004/07/Silogik.Reclutamiento.Model")]
    [System.SerializableAttribute()]
    public partial class Log : Test_sislogik.WS_LoggerService.Entity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> LevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MetadataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Level {
            get {
                return this.LevelField;
            }
            set {
                if ((this.LevelField.Equals(value) != true)) {
                    this.LevelField = value;
                    this.RaisePropertyChanged("Level");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Metadata {
            get {
                return this.MetadataField;
            }
            set {
                if ((object.ReferenceEquals(this.MetadataField, value) != true)) {
                    this.MetadataField = value;
                    this.RaisePropertyChanged("Metadata");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Entity", Namespace="http://schemas.datacontract.org/2004/07/Silogik.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Test_sislogik.WS_LoggerService.Log))]
    public partial class Entity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Level", Namespace="http://schemas.datacontract.org/2004/07/Silogik.Reclutamiento")]
    public enum Level : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Info = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Warning = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="www.silogik.com", ConfigurationName="WS_LoggerService.LoggerService")]
    public interface LoggerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="www.silogik.com/LoggerService/Historial", ReplyAction="www.silogik.com/LoggerService/HistorialResponse")]
        Test_sislogik.WS_LoggerService.Log[] Historial(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.silogik.com/LoggerService/Historial", ReplyAction="www.silogik.com/LoggerService/HistorialResponse")]
        System.Threading.Tasks.Task<Test_sislogik.WS_LoggerService.Log[]> HistorialAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.silogik.com/LoggerService/Log", ReplyAction="www.silogik.com/LoggerService/LogResponse")]
        void Log(string email, string message, Test_sislogik.WS_LoggerService.Level level, string metadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="www.silogik.com/LoggerService/Log", ReplyAction="www.silogik.com/LoggerService/LogResponse")]
        System.Threading.Tasks.Task LogAsync(string email, string message, Test_sislogik.WS_LoggerService.Level level, string metadata);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LoggerServiceChannel : Test_sislogik.WS_LoggerService.LoggerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoggerServiceClient : System.ServiceModel.ClientBase<Test_sislogik.WS_LoggerService.LoggerService>, Test_sislogik.WS_LoggerService.LoggerService {
        
        public LoggerServiceClient() {
        }
        
        public LoggerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoggerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoggerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoggerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Test_sislogik.WS_LoggerService.Log[] Historial(string email) {
            return base.Channel.Historial(email);
        }
        
        public System.Threading.Tasks.Task<Test_sislogik.WS_LoggerService.Log[]> HistorialAsync(string email) {
            return base.Channel.HistorialAsync(email);
        }
        
        public void Log(string email, string message, Test_sislogik.WS_LoggerService.Level level, string metadata) {
            base.Channel.Log(email, message, level, metadata);
        }
        
        public System.Threading.Tasks.Task LogAsync(string email, string message, Test_sislogik.WS_LoggerService.Level level, string metadata) {
            return base.Channel.LogAsync(email, message, level, metadata);
        }
    }
}
