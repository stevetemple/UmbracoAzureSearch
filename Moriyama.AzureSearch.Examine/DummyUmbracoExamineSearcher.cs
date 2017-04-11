﻿using Examine;
using Examine.SearchCriteria;
using Moriyama.AzureSearch.Umbraco.Application;
using System;
using System.IO;
using UmbracoExamine;

namespace Moriyama.AzureSearch.Examine
{
    public class DummyUmbracoExamineSearcher : UmbracoExamineSearcher
    {
        public override ISearchResults Search(ISearchCriteria searchParams)
        {
            // Video Nasty
            var s = searchParams.ToString();
            int id = 0;

            try
            {
                s = s.Substring(s.IndexOf("NodeId:") + 7);
                s = s.Substring(0, s.IndexOf(" "));

                int.TryParse(s, out id);

                if(id > 0)
                {
                    var client = AzureSearchContext.Instance;
                    var media = client.SearchClient.Media().Filter("Id", id.ToString()).Results();

                    if(media.Count == 1)
                    {
                        var mediaItem = media.Content[0];

                    }
                }

            }
            catch (Exception ex)
            {

            }

            throw new FileNotFoundException("");       
                    
        }
    }
}
