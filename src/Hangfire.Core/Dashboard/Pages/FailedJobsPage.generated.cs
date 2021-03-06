﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class FailedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Failed Jobs" };

    int from, perPage;

    int.TryParse(Request.Query["from"], out from);
    int.TryParse(Request.Query["count"], out perPage);

    var monitor = Storage.GetMonitoringApi();
    Pager pager = new Pager(from, perPage, monitor.FailedCount())
    {
        BasePageUrl = Request.LinkTo("/failed")
    };

    JobList<FailedJobDto> failedJobs = monitor
        .FailedJobs(pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 26 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-success\">\r\n        You have no failed jobs at the mom" +
"ent.\r\n    </div>\r\n");


            
            #line 31 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 37 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                         Write(Request.LinkTo("/failed/requeue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Enqueueing..."">
                <span class=""glyphicon glyphicon-repeat""></span>
                Requeue jobs
            </button>

            <button class=""js-jobs-list-command btn btn-sm btn-default""
                    data-url=""");


            
            #line 44 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                         Write(Request.LinkTo("/failed/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 51 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table failed-table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th>Failed</th>
                    <th>Job</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 66 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                   var index = 0; 

            
            #line default
            #line hidden

            
            #line 67 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                 foreach (var job in failedJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row ");


            
            #line 69 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                            Write(!job.Value.InFailedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 69 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                                                                 Write(job.Value.InFailedState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td rowspan=\"");


            
            #line 70 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                 Write(job.Value.InFailedState ? "2" : "1");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");


            
            #line 71 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                             if (job.Value.InFailedState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input type=\"checkbox\" class=\"js-jobs-list-checkb" +
"ox\" name=\"jobs[]\" value=\"");


            
            #line 73 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                                                                     Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 74 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\" rows" +
"pan=\"");


            
            #line 76 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                   Write(job.Value.InFailedState ? "2" : "1");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <a href=\"");


            
            #line 77 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 78 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 80 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                             if (!job.Value.InFailedState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 83 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n");


            
            #line 86 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                             if (job.Value.FailedAt.HasValue)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span data-moment=\"");


            
            #line 88 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                              Write(JobHelper.ToTimestamp(job.Value.FailedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 89 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                               Write(job.Value.FailedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");


            
            #line 91 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td>\r\n                    " +
"        <div>\r\n                                <a class=\"job-method\" href=\"");


            
            #line 95 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                       Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 96 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                               Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </a>\r\n                            </div>\r\n");


            
            #line 99 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                             if (!String.IsNullOrEmpty(job.Value.ExceptionMessage))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div style=\"color: #888;\">\r\n                     " +
"               ");


            
            #line 102 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                               Write(job.Value.Reason);

            
            #line default
            #line hidden
WriteLiteral(" <a class=\"expander\" href=\"#\">More&nbsp;details...</a>\r\n                         " +
"       </div>\r\n");


            
            #line 104 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");


            
            #line 107 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                    if (job.Value.InFailedState)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td colspan=\"2\" class=\"" +
"failed-job-details\">\r\n                                <div class=\"expandable\" st" +
"yle=\"");


            
            #line 111 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                           Write(index++ == 0 ? "display: block;" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    <h4>");


            
            #line 112 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                   Write(job.Value.ExceptionType);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                                    <p>\r\n                                 " +
"       ");


            
            #line 114 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                   Write(job.Value.ExceptionMessage);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </p>\r\n\r\n");


            
            #line 117 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                     if (!String.IsNullOrEmpty(job.Value.ExceptionDetails))
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <pre class=\"stack-trace\">");


            
            #line 119 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                                            Write(HtmlHelper.MarkupStackTrace(job.Value.ExceptionDetails));

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n");


            
            #line 120 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </div>\r\n                            </td>\r\n      " +
"                  </tr>\r\n");


            
            #line 124 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 129 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"

    
            
            #line default
            #line hidden
            
            #line 130 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 130 "..\..\Dashboard\Pages\FailedJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
