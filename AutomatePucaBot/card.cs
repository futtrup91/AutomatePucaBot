using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatePucaBot
{
    public class Card
    {
        private Member m;
        private string cardName { get; set; }
        private string cardValue { get; set; }
        private string tradeUrl { get; set; }

        public Card(string cardName, string cardValue, string tradeUrl, Member m)
        {
            this.cardName = cardName;
            this.cardValue = cardValue;
            this.tradeUrl = tradeUrl;
            this.m = m;
        }


  

      

    }
}
