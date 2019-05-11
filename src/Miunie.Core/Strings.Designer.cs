﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Miunie.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Miunie.Core.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Sorry {0}, you cannot influence your own reputation! Try influencing other people instead. :smirk:{{OR}}
        ///Aww, {0}... I can&apos;t do that. If you need your reputation to change, try blackmailing others to do it for you.{{OR}}
        ///Hey {0}, did you really think you could influence yourself? Get some friends to do that for you.{{OR}}
        ///Did {0} just try to influence someone that isn&apos;t me?! Wait, they tried to self-rep? Hah!.
        /// </summary>
        public static string CANNOT_SELF_REP {
            get {
                return ResourceManager.GetString("CANNOT_SELF_REP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :calendar: Creation date.
        /// </summary>
        public static string GUILD_EMBED_CREATED_AT_TITLE {
            get {
                return ResourceManager.GetString("GUILD_EMBED_CREATED_AT_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        public static string GUILD_EMBED_NAME_TITLE {
            get {
                return ResourceManager.GetString("GUILD_EMBED_NAME_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Roles.
        /// </summary>
        public static string GUILD_EMBED_ROLES_TITLE {
            get {
                return ResourceManager.GetString("GUILD_EMBED_ROLES_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server stats.
        /// </summary>
        public static string GUILD_EMBED_STATS_TITLE {
            get {
                return ResourceManager.GetString("GUILD_EMBED_STATS_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to **ABOUT THIS SERVER**.
        /// </summary>
        public static string GUILD_EMBED_TITLE {
            get {
                return ResourceManager.GetString("GUILD_EMBED_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to **{0}** just got reputation from {1}! :trophy:{{OR}}
        ///**{0}** just got reputation from {1}! :fireworks:{{OR}}
        ///**{0}** just got reputation from {1}! :tada:{{OR}}
        ///**{0}** was given some reputation by {1}! What&apos;s in it for me, though? :thinking:.
        /// </summary>
        public static string REPUTATION_GIVEN {
            get {
                return ResourceManager.GetString("REPUTATION_GIVEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to **{0}** just had reputation removed from {1} :({{OR}}
        ///**{0}** just had reputation removed from {1} :&apos;({{OR}}
        ///**{0}** just had reputation removed from {1} :sob:.
        /// </summary>
        public static string REPUTATION_TAKEN {
            get {
                return ResourceManager.GetString("REPUTATION_TAKEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can find my source code on GitHub:
        ///https://github.com/discord-bot-tutorial/Miunie.
        /// </summary>
        public static string SHOW_REMOTE_REPO {
            get {
                return ResourceManager.GetString("SHOW_REMOTE_REPO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :calendar_spiral: Creation date.
        /// </summary>
        public static string USER_EMBED_CREATED_AT_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_CREATED_AT_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to _A software person._{{OR}}
        ///_A bot._ :robot:{{OR}}
        ///_Soon to be our AI overlord._.
        /// </summary>
        public static string USER_EMBED_IS_BOT {
            get {
                return ResourceManager.GetString("USER_EMBED_IS_BOT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to _Passes ReCaptcha,
        ///so I guess they&apos;re real._{{OR}}
        ///_A real human being._{{OR}}
        ///_Real flesh, bones,
        ///blood, all that._.
        /// </summary>
        public static string USER_EMBED_IS_HUMAN {
            get {
                return ResourceManager.GetString("USER_EMBED_IS_HUMAN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :calendar: Joined.
        /// </summary>
        public static string USER_EMBED_JOINED_AT_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_JOINED_AT_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :label: Name.
        /// </summary>
        public static string USER_EMBED_NAME_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_NAME_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :electric_plug: Bot or not{{OR}}
        ///:electric_plug: Human/Bot.
        /// </summary>
        public static string USER_EMBED_REALNESS_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_REALNESS_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :fleur_de_lis: Reputation.
        /// </summary>
        public static string USER_EMBED_REP_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_REP_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to :dolls: Roles.
        /// </summary>
        public static string USER_EMBED_ROLES_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_ROLES_TITLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to **YOUR AWESOME PROFILE**{{OR}}
        ///**YOUR COOL PROFILE**{{OR}}
        ///**YOUR MAGNIFICENT PROFILE**{{OR}}
        ///**YOUR DANK PROFILE**.
        /// </summary>
        public static string USER_EMBED_TITLE {
            get {
                return ResourceManager.GetString("USER_EMBED_TITLE", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sure{{OR}}
        ///I don&apos;t know...{{OR}}
        ///Nah.
        /// </summary>
        public static string YES_NO_MAYBE
        {
            get
            {
                return ResourceManager.GetString("YES_NO_MAYBE", resourceCulture);
            }
        }
    }
}
