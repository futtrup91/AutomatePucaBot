using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatePucaBot
{
    public class Member
    {
        public string memberName { get; set; }
        private string url { get; set; }
        private string memberPoints { get; set; }

        private List<Card> cards { get;
        }

        public Member(string memberName, string memberPoints, string url)
        {
            this.memberName = memberName;
            this.memberPoints = memberPoints;
            this.url = url;
            cards = new List<Card>();
        }

        public void addCard(Card c1)
        {
            cards.Add(c1);
        }
       
    }
}
