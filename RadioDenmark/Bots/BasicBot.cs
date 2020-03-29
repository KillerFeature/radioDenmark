using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RadioDenmark.Bots
{
    public class BasicBot : IBot
    {
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {

            await turnContext.SendActivityAsync(MessageFactory.Text("hello", "welcomeText"), cancellationToken);

            //throw new NotImplementedException();
        }
    }
}
