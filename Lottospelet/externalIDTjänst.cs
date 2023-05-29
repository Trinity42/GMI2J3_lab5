using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottospelet
{
	public class externalIDTjänst : IexternalIDTjänst
	{
		public bool Authenticate(string username, string password)
		{
			bool isRight = false;
			if (username == "LifeSux" && password == "BraLösenOrd")
				isRight = true;
			return isRight;
		}
	}
}
