# InterestDb

Hämta alla personer => /api/Person

Hämta alla intressen som är kopplade till en specifik person => /api/Interest/personId

Hämta alla länkar som är kopplade till en specifik person => /api/InterestLink/personId

Koppla en person till ett nytt intresse => /api/InterestLink/{interestLinkId} body: { "interestLinkId": 0, "url": "string", "fK_PersonId": 0, "fK_InterestId": 0 }

Lägga in nya länkar för en specifik person och ett specifikt intresse => /api/InterestLink body: {"url": "string", "fK_PersonId": 0, "fK_InterestId": 0 }
