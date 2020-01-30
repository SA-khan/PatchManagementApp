<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HelloWorld.ProtectedPages.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style>
#chart {
    height: 440px;
}
</style>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script>    $.jqplot('chartdiv', [[[1, 2], [3, 5.12], [5, 13.1], [7, 33.6], [9, 85.9], [11, 219.9]]]);</script>
<script>    $(document).ready(function () {
        var s1 = [[2002, 112000], [2003, 122000], [2004, 104000], [2005, 99000], [2006, 121000],
    [2007, 148000], [2008, 114000], [2009, 133000], [2010, 161000], [2011, 173000]];
        var s2 = [[2002, 10200], [2003, 10800], [2004, 11200], [2005, 11800], [2006, 12400],
    [2007, 12800], [2008, 13200], [2009, 12600], [2010, 13100]];

        plot1 = $.jqplot("chart1", [s2, s1], {
            // Turns on animatino for all series in this plot.
            animate: true,
            // Will animate plot on calls to plot1.replot({resetAxes:true})
            animateReplot: true,
            cursor: {
                show: true,
                zoom: true,
                looseZoom: true,
                showTooltip: false
            },
            series: [
            {
                pointLabels: {
                    show: true
                },
                renderer: $.jqplot.BarRenderer,
                showHighlight: false,
                yaxis: 'y2axis',
                rendererOptions: {
                    // Speed up the animation a little bit.
                    // This is a number of milliseconds.  
                    // Default for bar series is 3000.  
                    animation: {
                        speed: 2500
                    },
                    barWidth: 15,
                    barPadding: -15,
                    barMargin: 0,
                    highlightMouseOver: false
                }
            },
            {
                rendererOptions: {
                    // speed up the animation a little bit.
                    // This is a number of milliseconds.
                    // Default for a line series is 2500.
                    animation: {
                        speed: 2000
                    }
                }
            }
        ],
            axesDefaults: {
                pad: 0
            },
            axes: {
                // These options will set up the x axis like a category axis.
                xaxis: {
                    tickInterval: 1,
                    drawMajorGridlines: false,
                    drawMinorGridlines: true,
                    drawMajorTickMarks: false,
                    rendererOptions: {
                        tickInset: 0.5,
                        minorTicks: 1
                    }
                },
                yaxis: {
                    tickOptions: {
                        formatString: "$%'d"
                    },
                    rendererOptions: {
                        forceTickAt0: true
                    }
                },
                y2axis: {
                    tickOptions: {
                        formatString: "$%'d"
                    },
                    rendererOptions: {
                        // align the ticks on the y2 axis with the y axis.
                        alignTicks: true,
                        forceTickAt0: true
                    }
                }
            },
            highlighter: {
                show: true,
                showLabel: true,
                tooltipAxes: 'y',
                sizeAdjust: 7.5, tooltipLocation: 'ne'
            }
        });

    });
</script>
<script>
    $(document).ready(function () {
        $("p").click(function () {
            $(this).hide();
        });
    });
</script>
    <script>
        $(function () {
            var populationData = [{
                arg: 1950,
                val: 2525778669
            }, {
                arg: 1960,
                val: 3026002942
            }, {
                arg: 1970,
                val: 3691172616
            }, {
                arg: 1980,
                val: 4449048798
            }, {
                arg: 1990,
                val: 5320816667
            }, {
                arg: 2000,
                val: 6127700428
            }, {
                arg: 2010,
                val: 6916183482
            }];
            $("#chart").dxChart({
                dataSource: populationData,
                legend: {
                    visible: false
                },
                series: {
                    type: "bar"
                },
                argumentAxis: {
                    tickInterval: 10,
                    label: {
                        format: {
                            type: "decimal"
                        }
                    }
                },
                title: "World Population by Decade"
            });
        });
    </script>
    

        <script>
            $(function () {
                var data = complaintsData.sort(function (a, b) {
                    return b.count - a.count;
                }),
        totalCount = data.reduce(function (prevValue, item) {
            return prevValue + item.count;
        }, 0),
        cumulativeCount = 0,
        dataSource = data.map(function (item, index) {
            cumulativeCount += item.count;
            return {
                complaint: item.complaint,
                count: item.count,
                cumulativePercentage: Math.round(cumulativeCount * 100 / totalCount)
            };
        });

                $("#chart").dxChart({
                    palette: "Harmony Light",
                    dataSource: dataSource,
                    title: "Pizza Shop Complaints",
                    argumentAxis: {
                        label: {
                            overlappingBehavior: "stagger"
                        }
                    },
                    tooltip: {
                        enabled: true,
                        shared: true,
                        customizeTooltip: function (info) {
                            return {
                                html: "<div><div class='tooltip-header'>" +
                    info.argumentText + "</div>" +
                    "<div class='tooltip-body'><div class='series-name'>" +
                    info.points[0].seriesName +
                    ": </div><div class='value-text'>" +
                    info.points[0].valueText +
                    "</div><div class='series-name'>" +
                    info.points[1].seriesName +
                    ": </div><div class='value-text'>" +
                    info.points[1].valueText +
                    "% </div></div></div>"
                            };
                        }
                    },
                    valueAxis: [{
                        name: "frequency",
                        position: "left",
                        tickInterval: 300
                    }, {
                        name: "percentage",
                        position: "right",
                        showZero: true,
                        label: {
                            customizeText: function (info) {
                                return info.valueText + "%";
                            }
                        },
                        constantLines: [{
                            value: 80,
                            color: "#fc3535",
                            dashStyle: "dash",
                            width: 2,
                            label: { visible: false }
                        }],
                        tickInterval: 20,
                        valueMarginsEnabled: false
                    }],
                    commonSeriesSettings: {
                        argumentField: "complaint"
                    },
                    series: [{
                        type: "bar",
                        valueField: "count",
                        axis: "frequency",
                        name: "Complaint frequency",
                        color: "#fac29a"
                    }, {
                        type: "spline",
                        valueField: "cumulativePercentage",
                        axis: "percentage",
                        name: "Cumulative percentage",
                        color: "#6b71c3"
                    }],
                    legend: {
                        verticalAlignment: "top",
                        horizontalAlignment: "center"
                    }
                });
            });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Panel2" Width="100%" runat="server" style="margin:auto;padding:auto;">
                <asp:Panel ID="Panel3" Width="40%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart" width="10" height="7"></canvas>
                </asp:Panel>
                <asp:Panel ID="Panel4" Width="40%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart2" width="10" height="7"></canvas>
                </asp:Panel>

                <br />

                <asp:Panel ID="Panel5" Width="40%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart3" width="10" height="7"></canvas>
                </asp:Panel>
                <asp:Panel ID="Panel6" Width="40%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart4" width="10" height="7"></canvas>
                </asp:Panel>

        </asp:Panel>
        <script type="text/javascript">
             var jsVariable = <%= serializer.Serialize(clientList) %>;
             console.log(jsVariable);
        </script>
        <script type="text/javascript">
            var ctx = document.getElementById('myChart');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',
                // The data for our dataset
                data: {
                    labels: [jsVariable[0], jsVariable[1], jsVariable[2], jsVariable[3], jsVariable[4], jsVariable[5]],
                    title: {display: true,
                    text: 'Number of Releases Deployed',
                    position: 'bottom'},
                    datasets: [{
                        label: 'Number of Releases Deployed ClientWise',
                        backgroundColor: 'rgb(75,108,158)',
                        borderColor: 'rgb(0,0,128)',
                        data: [0, 10, 5, 2, 20, 30, 45]
                    }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Number Of Releases Deployed Clientwise',
                        ForeColor: 'rgb(255, 255, 255)'
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                },
                // Configuration options go here
                animation: {
                    duration: 6000,
                    onProgress: function (animation) {
                        progress.value = animation.animationObject.currentStep / animation.animationObject.numSteps;
                    }
                }
            });
            var ctx = document.getElementById('myChart2');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'bar',
                // The data for our dataset
                data: {
                    labels: ["Alfalah", "HBL", "UBL", "Alfalah", "HBL", "UBL"],
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: 'rgb(75,108,158)',
                        borderColor: 'rgb(0, 0, 128)',
                        data: [0, 10, 5, 2, 20, 30, 45]
                    }]
                },
                // Configuration options go here
                options: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Number Of Releases Deployed Clientwise',
                        ForeColor: 'rgb(255, 255, 255)'
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
            var ctx = document.getElementById('myChart3');
            var myDoughnutChart = new Chart(ctx, {
                type: 'doughnut',
                data: { labels: ["Alfalah", "HBL", "UBL", "Alfalah", "HBL", "UBL"],
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: 'rgb(75,108,158)',
                        borderColor: 'rgb(0, 0, 128)',
                        data: [0, 10, 5, 2, 20, 30, 45]
                    }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'Number Of Releases Deployed Clientwise',
                        ForeColor: 'rgb(255, 255, 255)'
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
            var ctx = document.getElementById('myChart4');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'polarArea',
                // The data for our dataset
                data: {
                    labels: ["Alfalah", "HBL", "UBL", "Alfalah", "HBL", "UBL"],
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: 'rgb(75,108,158)',
                        borderColor: 'rgb(0, 0, 128)',
                        data: [0, 10, 5, 2, 20, 30, 45]
                    }]
                },
                // Configuration options go here
                options: {
                    title: {
                         display: true,
                         text: 'Number Of Releases Deployed Clientwise',
                         ForeColor: 'rgb(255, 255, 255)'
                    },
                    legend: {
                        display: false
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
            </script>
        </ContentTemplate>
        </asp:UpdatePanel>
            <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ProtectedPages/EditEnvironemtInfo.aspx">Update Patch Link</asp:HyperLink>--%>
    </asp:Panel>

</asp:Content>
