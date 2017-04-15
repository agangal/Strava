#region Copyright (C) 2014-2016 Sascha Simon

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
using Strava.Api;
using StravaDotNet;using SharedLibrary;
using StravaUWP.Helper;
namespace StravaDotNet
{
    /// <summary>
    /// Used to receive information about gear.
    /// </summary>
    public class GearClient 
    {
        /// <summary>
        /// Initializes a new instance of the GearClient class.
        /// </summary>
        /// <param name="auth"></param>
        public GearClient() { }

        #region Async

        /// <summary>
        /// Retrieves gear with the specified id asynchronously from the Strava servers.
        /// </summary>
        /// <param name="gearId">The Strava id of the gear.</param>
        /// <returns>The gear object.</returns>
        public async Task<Bike> GetGearAsync(string gearId)
        {
            string getUrl = string.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, AuthSettings.ScopeAccessToken);
            string json = await StravaUWP.Helper.HttpHelper.GetRequestAsync(getUrl);;

            return Unmarshaller<Bike>.Unmarshal(json);
        }

        #endregion

        #region Sync

        /// <summary>
        /// Retrieves gear with the specified id from the Strava servers.
        /// </summary>
        /// <param name="gearId">The Strava id of the gear.</param>
        /// <returns>The gear object.</returns>
        public Bike GetGear(string gearId)
        {
            string getUrl = string.Format("{0}/{1}?access_token={2}", Endpoints.Gear, gearId, AuthSettings.ScopeAccessToken);
            string json = HttpHelper.GetRequest(getUrl);

            return Unmarshaller<Bike>.Unmarshal(json);
        }

        #endregion
    }
}
