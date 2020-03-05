using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xna.Framework.GamerServices
{
    public static class Guide
    {
        public static bool IsVisible { get; }
        public static bool IsTrialMode { get; internal set; }

        public static void BeginShowMessageBox( string a1, string a2, IEnumerable<string> a3, int a4, MessageBoxIcon a5, AsyncCallback a6, object a7 )
        {
            Debug.WriteLine( "Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox()" );
        }

        public static int? EndShowMessageBox(IAsyncResult a1) 
        {
            Debug.WriteLine( "Microsoft.Xna.Framework.GamerServices.Guide.EndShowMessageBox()" );
            return 0;
        }

        internal static void ShowMarketplace( PlayerIndex playerIndex )
        {
            Debug.WriteLine( "Microsoft.Xna.Framework.GamerServices.Guide.ShowMarketplace()" );
        }

        public static bool IsScreenSaverEnabled { get; internal set; }
    }

    public enum MessageBoxIcon
    {

    }

    public class SignedInGamer : Gamer
    {
        public bool IsSignedInToLive { get; internal set; } = false;
        public GamerPrivilegeSettings Privileges { get; internal set; } = new GamerPrivilegeSettings();
        public static Action<object, SignedInEventArgs> SignedIn { get; internal set; }

        internal void BeginGetAchievements( AsyncCallback asyncCallback, object gamer )
        {
        }

        internal List<Achievement> EndGetAchievements( IAsyncResult result )
        {
            return new List<Achievement>();
        }

        internal void BeginAwardAchievement( string achievementKey, AsyncCallback asyncCallback, object gamer )
        {
        }

        internal void EndAwardAchievement( IAsyncResult result )
        {
        }
    }

    public class GamerPrivilegeSettings
    {
        public GamerPrivilegeSetting AllowProfileViewing { get; internal set; }
    }

    public class SignedInEventArgs
    {
        public SignedInGamer Gamer { get; internal set; } = new SignedInGamer();
    }

    public class GameUpdateRequiredException : Exception
    {
        public GameUpdateRequiredException()
        {

        }

        public GameUpdateRequiredException(string message)
            : base(message)
        {

        }
    }

    public class LeaderboardReader
    {
        public LeaderboardIdentity LeaderboardIdentity { get; internal set; } = new LeaderboardIdentity();
        public List<LeaderboardEntry> Entries { get; internal set; } = new List<LeaderboardEntry>();

        internal static void BeginRead( object p, Gamer signedInGamer1, int v, AsyncCallback asyncCallback, object signedInGamer2 )
        {
        }

        internal static LeaderboardReader EndRead( IAsyncResult result )
        {
            return new LeaderboardReader();
        }
    }

    public class Gamer
    {
        public static SignedInGamer[] SignedInGamers { get; } = new SignedInGamer[1];
        public string Gamertag { get; internal set; } = string.Empty;
        public LeaderboardWriter LeaderboardWriter { get; internal set; } = new LeaderboardWriter();

        internal void BeginGetProfile( AsyncCallback asyncCallback, object gamer )
        {
        }

        internal GamerProfile EndGetProfile( IAsyncResult result )
        {
            return new GamerProfile();
        }
    }

    public class LeaderboardWriter
    {
        internal LeaderboardEntry GetLeaderboard( LeaderboardIdentity leaderboardIdentity )
        {
            throw new NotImplementedException();
        }
    }

    public class LeaderboardIdentity
    {
        public int GameMode { get; internal set; }

        internal static LeaderboardIdentity Create( LeaderboardKey leaderboardKey, int mode )
        {
            return new LeaderboardIdentity();
        }
    }

    public enum LeaderboardKey
    {

    }

    public class LeaderboardEntry
    {
        public Gamer Gamer { get; internal set; } = new Gamer();
        public LeaderboardEntryColumns Columns { get; internal set; } = new LeaderboardEntryColumns();
        public long Rating { get; internal set; }
    }

    public class LeaderboardEntryColumns
    {
        internal int GetValueInt32( string v )
        {
            return 0;
        }

        internal DateTime GetValueDateTime( string v )
        {
            return new DateTime();
        }

        internal void SetValue( string v, DateTime now )
        {
        }

        internal void SetValue( string v, int value )
        {
        }
    }

    public class GamerProfile
    {

    }

    public enum GamerPrivilegeSetting
    {

    }

    public class Achievement
    {
        public string Key { get; internal set; } = string.Empty;
        public bool IsEarned { get; internal set; } = false;
    }
}
