// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;


namespace RadioDenmark.Bots
{
    public class RadioDenmarkBot : IBot
    {

        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            var activity = turnContext.Activity;

            switch (activity.Type)
            {
                case ActivityTypes.Message:
                    await turnContext.SendActivityAsync(radioDk.GetResponse(turnContext.Activity.Text), cancellationToken);
                    Activity a = new Activity();
                    a.Type = ActivityTypes.EndOfConversation;
                    await turnContext.SendActivityAsync(a, cancellationToken);
                    break;
                case ActivityTypes.ConversationUpdate:
                    await turnContext.SendActivityAsync(MessageFactory.Text(text: "Hello", ssml: "Hello", inputHint: InputHints.ExpectingInput), cancellationToken);
                    break;
                default:
                    await turnContext.SendActivityAsync(MessageFactory.Text(text: "Hello", ssml: "Hello", inputHint: InputHints.ExpectingInput), cancellationToken);
                    break;
            }





            //throw new System.NotImplementedException();
        }
    }
    public class radioDk
    {
        private static string GenerateSSML(string text, string lang)
        {
            string output;
            switch (lang)
            {
                case "da":
                    output = "<speak version =\"1.0\" xmlns:ssml=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"da-DK\"><voice name=\"Microsoft Server Speech Text to Speech Voice (da-DK, Helle)\">" + text + "</voice></speak >";

                    break;
                default:
                    output = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">" + text + "</speak>";
                    break;
            }



            return "";
        }

        public static IActivity GetResponse(string inputText)
        {
            List<RadioItem> radioItems = new List<RadioItem> {
                new RadioItem {DisplayName = "P1", Regex="(pe?a?e?\\s?(1|one|on)|(\\w+)?\\s?one|\\w+ want|keyboard|people)", MediaUri = "http://live-icy.gslb01.dr.dk:80/A/A03H.mp3", Type = RadioItem.RadioItemType.Stream },
                new RadioItem {DisplayName = "P2", Regex="(pe?a?e?\\s?(2|two|too)|(\\w+)?\\s?two)", MediaUri = "http://live-icy.gslb01.dr.dk:80/A/A04H.mp3", Type = RadioItem.RadioItemType.Stream },
                new RadioItem {DisplayName = "P3", Regex="(pe?a?e?\\s?(3|th?ree)|(\\w+)?\\s?th?ree)", MediaUri = "http://live-icy.gslb01.dr.dk:80/A/A05H.mp3", Type = RadioItem.RadioItemType.Stream },
                new RadioItem {DisplayName = "Radio 4", Regex="radio\\s?(4|four)", MediaUri = "http://netradio.radio4.dk/radio4", Type = RadioItem.RadioItemType.Stream },
                new RadioItem {DisplayName = "The Short Corona", Regex="(short\\s?|corona)", MediaUri = "https://www.spreaker.com/show/4269133/episodes/feed", Type = RadioItem.RadioItemType.Podcast, SSML = "<speak version=\"1.0\" xmlns:ssml=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"da-DK\">  <voice name=\"Microsoft Server Speech Text to Speech Voice (da-DK, Helle)\">Den Korte Coronavis" },
                new RadioItem {DisplayName = "Verden ifølge Gram", Regex="(gram|the world)", MediaUri = "https://www.dr.dk/mu/feed/verden-ifoelge-gram.xml?format=podcast", Type = RadioItem.RadioItemType.Podcast },
                new RadioItem {DisplayName = "Orientering", Regex="(orientation)", MediaUri = "https://www.dr.dk/mu/feed/orientering.xml?format=podcast", Type = RadioItem.RadioItemType.Podcast }


        };



            foreach (RadioItem item in radioItems)
            {
                Regex regex = new Regex(item.Regex);
                if (regex.IsMatch(inputText))
                {
                    List<MediaUrl> mediaUrls = new List<MediaUrl>();

                    MediaUrl mediaURL;

                    if (item.Type == RadioItem.RadioItemType.Podcast)
                    {
                        podcast.podcast p = new podcast.podcast();

                        mediaUrls.Add(new MediaUrl(p.getLatestPodcast(item.MediaUri)));
                    }
                    else
                    {
                        mediaUrls.Add(new MediaUrl(item.MediaUri));
                    }
                    AudioCard ac = new AudioCard(media: mediaUrls, autostart: true);
                    return MessageFactory.Attachment(ac.ToAttachment(), ssml: "Playing "+ item.DisplayName);
                }
            };
            return MessageFactory.Text("Text I didn't understand " + inputText, ssml: "I didn't understand " + inputText, inputHint: InputHints.ExpectingInput);
        }


    }
    public class RadioItem
    {
        public string DisplayName { get; set; }
        public string MediaUri { get; set; }
        public string Regex { get; set; }
        public RadioItemType Type { get; set; }
        public string MimeType { get; set; }
        public string SSML { get; set; }
        public enum RadioItemType
        {
            Stream,
            Podcast
        };


    }
}
