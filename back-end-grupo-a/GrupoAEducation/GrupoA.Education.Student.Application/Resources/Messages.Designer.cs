﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrupoA.Education.Student.Application.Resources {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("GrupoA.Education.Student.Application.Resources.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string StudentNotFound {
            get {
                return ResourceManager.GetString("StudentNotFound", resourceCulture);
            }
        }
        
        internal static string UnexpectedErrorOn {
            get {
                return ResourceManager.GetString("UnexpectedErrorOn", resourceCulture);
            }
        }
        
        internal static string ErrorOnCommit {
            get {
                return ResourceManager.GetString("ErrorOnCommit", resourceCulture);
            }
        }
        
        internal static string ErrorOnUpdate {
            get {
                return ResourceManager.GetString("ErrorOnUpdate", resourceCulture);
            }
        }
        
        internal static string StudentWithRaAlreadyExists {
            get {
                return ResourceManager.GetString("StudentWithRaAlreadyExists", resourceCulture);
            }
        }
        
        internal static string StudentWithItinAlreadyExists {
            get {
                return ResourceManager.GetString("StudentWithItinAlreadyExists", resourceCulture);
            }
        }
        
        internal static string StudentWithMailAlreadyExists {
            get {
                return ResourceManager.GetString("StudentWithMailAlreadyExists", resourceCulture);
            }
        }
        
        internal static string CpfIsNotValid {
            get {
                return ResourceManager.GetString("CpfIsNotValid", resourceCulture);
            }
        }
        
        internal static string MailIsMandatory {
            get {
                return ResourceManager.GetString("MailIsMandatory", resourceCulture);
            }
        }
        
        internal static string MailIsNotValid {
            get {
                return ResourceManager.GetString("MailIsNotValid", resourceCulture);
            }
        }
        
        internal static string StudentNameIsMandatory {
            get {
                return ResourceManager.GetString("StudentNameIsMandatory", resourceCulture);
            }
        }
        
        internal static string StudentNameIsTooShort {
            get {
                return ResourceManager.GetString("StudentNameIsTooShort", resourceCulture);
            }
        }
    }
}
