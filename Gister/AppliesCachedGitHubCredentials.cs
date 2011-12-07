using System;
using System.IO;
using EchelonTouchInc.Gister.Api;

namespace EchelonTouchInc.Gister
{
    public class AppliesCachedGitHubCredentials : AppliesCredentials
    {
        public string TestPathToCredentials { get; set; }

        public void Apply(CanReceiveCredentials receiver)
        {
            var credentials = GetCredentials();

            receiver.UseCredentials(credentials);
        }

        private GitHubCredentials GetCredentials()
        {
            var pathToCredentialsFile = GetPathToCredentialsFile();
            var lines = File.ReadAllLines(pathToCredentialsFile);

            return DecodeGitHubCredentialsFromFile(lines);
        }

        private string GetPathToCredentialsFile()
        {
            return IsTestPathProvided() ?  TestPathToCredentials : VsProfileCredentials();
        }

        private static string VsProfileCredentials()
        {
            var profilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            return Path.Combine(profilePath, "github.creds");
        }

        private bool IsTestPathProvided()
        {
            return !string.IsNullOrEmpty(TestPathToCredentials);
        }

        private GitHubCredentials DecodeGitHubCredentialsFromFile(string[] lines)
        {
            return new GitHubCredentials(lines[0], lines[1]);
        }

        public bool IsAvailable()
        {
            return File.Exists(VsProfileCredentials());
        }
    }
}