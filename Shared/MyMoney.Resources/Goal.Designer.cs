﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMoney.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Goal {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Goal() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyMoney.Resources.Goal", typeof(Goal).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The requested goal could not be found..
        /// </summary>
        public static string Error_CouldNotFindGoal {
            get {
                return ResourceManager.GetString("Error_CouldNotFindGoal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Completed Goals.
        /// </summary>
        public static string Header_CompletedGoals {
            get {
                return ResourceManager.GetString("Header_CompletedGoals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current Goals.
        /// </summary>
        public static string Header_CurrentGoals {
            get {
                return ResourceManager.GetString("Header_CurrentGoals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Goals.
        /// </summary>
        public static string Header_YourGoals {
            get {
                return ResourceManager.GetString("Header_YourGoals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manage Goals.
        /// </summary>
        public static string Title_ManageGoals {
            get {
                return ResourceManager.GetString("Title_ManageGoals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Complete Goal.
        /// </summary>
        public static string Tooltip_Complete {
            get {
                return ResourceManager.GetString("Tooltip_Complete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete Goal.
        /// </summary>
        public static string Tooltip_Delete {
            get {
                return ResourceManager.GetString("Tooltip_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit Goal.
        /// </summary>
        public static string Tooltip_Edit {
            get {
                return ResourceManager.GetString("Tooltip_Edit", resourceCulture);
            }
        }
    }
}