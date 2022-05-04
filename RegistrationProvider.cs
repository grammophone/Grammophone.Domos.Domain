using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The provider by which the user is registered to the system.
	/// </summary>
	public enum RegistrationProvider
	{
		/// <summary>
		/// Registrationn using password.
		/// </summary>
		Native,

		/// <summary>
		/// Registration using Facebook.
		/// </summary>
		Facebook,

		/// <summary>
		/// Registgration using LinkedIn.
		/// </summary>
		LinkedIn,

		/// <summary>
		/// Registration using Twitter.
		/// </summary>
		Twitter,

		/// <summary>
		/// Registration using Google.
		/// </summary>
		Google,

		/// <summary>
		/// Registration using Mocrosoft's Live.
		/// </summary>
		Microsoft,

		/// <summary>
		/// Registration using Amazon.
		/// </summary>
		Amazon,

		/// <summary>
		/// Registration using ArcGIS.
		/// </summary>
		ArcGIS,

		/// <summary>
		/// Registration using Arsana.
		/// </summary>
		Arsana,

		/// <summary>
		/// Registration using Autodesk.
		/// </summary>
		Autodesk,

		/// <summary>
		/// Registration using BattleNet.
		/// </summary>
		BattleNet,

		/// <summary>
		/// Registration using Beam.
		/// </summary>
		Beam,

		/// <summary>
		/// Registration using BitBucket.
		/// </summary>
		BitBucket,

		/// <summary>
		/// Registration using Buffer.
		/// </summary>
		Buffer,

		/// <summary>
		/// Registration using CiscoSpark.
		/// </summary>
		CiscoSpark,

		/// <summary>
		/// Registration using DeviantArt.
		/// </summary>
		DeviantArt,

		/// <summary>
		/// Registration using Discord.
		/// </summary>
		Discord,

		/// <summary>
		/// Registration using Domos.
		/// </summary>
		Domos,

		/// <summary>
		/// Registration using Dropbox.
		/// </summary>
		Dropbox,

		/// <summary>
		/// Registration using EVEOnline.
		/// </summary>
		EVEOnline,

		/// <summary>
		/// Registration using Fitbit.
		/// </summary>
		Fitbit,

		/// <summary>
		/// Registration using Foursquare.
		/// </summary>
		Foursquare,

		/// <summary>
		/// Registration using Gab.
		/// </summary>
		Gab,

		/// <summary>
		/// Registration using GitHub.
		/// </summary>
		GitHub,

		/// <summary>
		/// Registration using Gitter.
		/// </summary>
		Gitter,

		/// <summary>
		/// Registration using HealthGraph.
		/// </summary>
		HealthGraph,

		/// <summary>
		/// Registration using Imgur.
		/// </summary>
		Imgur,

		/// <summary>
		/// Registration using Instagram.
		/// </summary>
		Instagram,

		/// <summary>
		/// Registration using MailChimp.
		/// </summary>
		MailChimp,

		/// <summary>
		/// Registration using Minds.
		/// </summary>
		Minds,

		/// <summary>
		/// Registration using Myob.
		/// </summary>
		Myob,

		/// <summary>
		/// Registration using Onshape.
		/// </summary>
		Onshape,

		/// <summary>
		/// Registration using Patreaon.
		/// </summary>
		Patreaon,

		/// <summary>
		/// Registration using Paypal.
		/// </summary>
		Paypal,

		/// <summary>
		/// Registration using QQ.
		/// </summary>
		QQ,

		/// <summary>
		/// Registration using Reddit.
		/// </summary>
		Reddit,

		/// <summary>
		/// Registration using Salesforce.
		/// </summary>
		Salesforce,

		/// <summary>
		/// Registration using Slack.
		/// </summary>
		Slack,

		/// <summary>
		/// Registration using SoundCloud.
		/// </summary>
		SoundCloud,

		/// <summary>
		/// Registration using Spotify.
		/// </summary>
		Spotify,

		/// <summary>
		/// Registration using StackExchange.
		/// </summary>
		StackExchange,

		/// <summary>
		/// Registration using Strava.
		/// </summary>
		Strava,

		/// <summary>
		/// Registration using SubscribeStar.
		/// </summary>
		SubscribeStar,

		/// <summary>
		/// Registration using Twitch,
		/// </summary>
		Twitch,

		/// <summary>
		/// Registration using Untappd.
		/// </summary>
		Untappd,

		/// <summary>
		/// Registration using Vimeo.
		/// </summary>
		Vimeo,

		/// <summary>
		/// Registration using VisualStudio.
		/// </summary>
		VisualStudio,

		/// <summary>
		/// Registration using VKontakte.
		/// </summary>
		VKontakte,

		/// <summary>
		/// Registration using Weibo.
		/// </summary>
		Weibo,

		/// <summary>
		/// Registration using Weixin.
		/// </summary>
		Weixin,

		/// <summary>
		/// Registration using WordPress.
		/// </summary>
		WordPress,

		/// <summary>
		/// Registration using Yahoo.
		/// </summary>
		Yahoo,

		/// <summary>
		/// Registration using Yammer.
		/// </summary>
		Yammer,

		/// <summary>
		/// Registration using Yandex.
		/// </summary>
		Yandex,

		/// <summary>
		/// Registration using Apple.
		/// </summary>
		Apple 
	}
}
