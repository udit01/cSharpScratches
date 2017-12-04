using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqFaroShuffle
{
    
    class PlayingCard
    {

        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public PlayingCard(Suit s, Rank r)
        {
            CardSuit = s;
            CardRank = r;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }

}
