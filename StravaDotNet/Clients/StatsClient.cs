#region Copyright (C) 2015 Sascha Simon

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

using System;
using System.Threading.Tasks;
using StravaDotNet;
using SharedLibrary;
using Strava.Statistics;

namespace StravaDotNet
{
    /// <summary>
    /// Used to get statistics data from Strava.
    /// </summary>
    public class StatsClient 
    {
        /// <summary>
        /// Initializes a new instance of the StatsClient class.
        /// </summary>
        /// <param name="auth">A IAuthenticator object that contains a valid Strava access token.</param>
        public StatsClient() { }

        #region async

        /// <summary>
        /// Gets some stats of the currently authenticated user.
        /// </summary>
        /// <param name="id">The id of the user. <remarks>Must match the authenticated athlete!</remarks></param>
        /// <returns>Strava statistics of the currently authenticated user.</returns>
        private async Task<Stats> GetStatsAsync(string id)
        {
            string getUrl = string.Format("https://www.strava.com/api/v3/athletes/{0}/stats?access_token={1}", id, AuthSettings.ScopeAccessToken);
            string json = await StravaUWP.Helper.HttpHelper.GetRequestAsync(getUrl);;

            return Unmarshaller<Stats>.Unmarshal(json);
        }

        /// <summary>
        /// Gets some stats of the currently authenticated user.
        /// </summary>
        /// <returns>Strava statistics of the currently authenticated user.</returns>
        public async Task<Stats> GetStatsAsync()
        {
            // Get the athlete
            AthleteClient client = new AthleteClient();
            Athlete a = await client.GetAthleteAsync();

            return await GetStatsAsync(a.Id.ToString());
        }

        #endregion

        #region sync
        #endregion
    }
}
