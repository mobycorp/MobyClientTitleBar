#region Moby Corp. Confidential / For Internal Use Only

// ***************************************************************************************
//
// Project:         Moby
//	Class:      	XmlHelper.cs
//
// Modification History:
//	Date:			March 10, 2022
//	By:				Stephen S. Miller
//	Comment:		Creation
//
// Copyright (c) 2010-2022, Moby Corp.
//
// All Rights Reserved.  Reproduction or transmission in whole or in part, in any form or
// by any means, electronic, mechanical or otherwise, is prohibited without the prior
// written consent of Moby Corp.
//
// Licensed Material - Property of Moby Corp.
//
// Moby Corp.
// 392 Shirley Gordon Road
// Woodland, WA 98674-9644 USA
// 
// ***************************************************************************************

#endregion

namespace MobyClient.Helpers;

public static class XmlHelper {

	#region Constructors

	#endregion

	#region Properties

	#endregion

	#region Methods

	public static List<MobyModule> GetMobyModules () {

		var fileLines = File.ReadAllText (Path.Combine (AppContext.BaseDirectory, "Schemas", "MobyModules.xml"));

		var serializer = new XmlSerializer (typeof (MobyModules));
		var stringReader = new StringReader (fileLines);
		var mobyModules = (MobyModules) serializer.Deserialize (stringReader);

		return mobyModules.Items.ToList ();
	}

	#endregion

	#region Fields

	#endregion
}