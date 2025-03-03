﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ludiq.PeekCore;

[assembly: MapToPlugin(typeof(Changelog_1_0_0), LudiqCore.ID)]

namespace Ludiq.PeekCore
{
	internal class Changelog_1_0_0 : PluginChangelog
	{
		public Changelog_1_0_0(Plugin plugin) : base(plugin) { }

		public override string description => "Initial Release";
		public override SemanticVersion version => "1.0.0";
		public override DateTime date => new DateTime(2017, 07, 26);
		public override IEnumerable<string> changes => Enumerable.Empty<string>();
	}
}