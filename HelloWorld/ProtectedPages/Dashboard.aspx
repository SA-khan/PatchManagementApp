<%@ Page Title="Portal - Dashboard" Language="C#" MasterPageFile="~/SiteLogout.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HelloWorld.ProtectedPages.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server" Height="455px" ScrollBars="Auto" GroupingText="Dashboard" BorderWidth="1" BorderColor="gray" ForeColor="Black" HorizontalAlign="Center" Font-Names="Arial" Font-Size="Medium" BackColor="LightGray" style="padding:2px;">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Panel2" Width="100%" runat="server" style="height:385px;;margin:auto;padding:auto;background-color:White;">
                <asp:Panel ID="Panel3" Width="45%" runat="server" style="float:left;margin:15px;border-color:gray;">
                    <canvas id="myChart" width="7" height="4"></canvas>
                </asp:Panel>
                <asp:Panel ID="Panel4" Width="45%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart2" width="7" height="4"></canvas>
                </asp:Panel>


                <p></p>
                <%--<br />--%>

                <asp:Panel ID="Panel5" Width="45%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart3" width="8" height="4"></canvas>
                </asp:Panel>
                <asp:Panel ID="Panel6" Width="45%" runat="server" style="float:left;margin:15px;">
                    <canvas id="myChart4" width="8" height="4"></canvas>
                </asp:Panel>

        </asp:Panel>

        
        <script type="text/javascript">
             var jsVariable = <%= serializer.Serialize(clientList) %>;
             console.log(jsVariable);
             var numberOfBuil = <%= serializer.Serialize(numberOfBuild) %>;
             console.log(numberOfBuil);
        </script>
        <script type="text/javascript">
            var ctx = document.getElementById('myChart');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',
                // The data for our dataset
                data: {
                    labels: [jsVariable[0], jsVariable[1], jsVariable[2], jsVariable[3], jsVariable[4], jsVariable[5], jsVariable[6], jsVariable[7], jsVariable[8], jsVariable[9], jsVariable[10]],
                    title: {display: true,
                    text: 'Number of Releases',
                    position: 'bottom'},
                    datasets: [{
                        label: 'Number of Releases ClientWise',
                        backgroundColor: 'rgb(75,108,158)',
                        borderColor: 'rgb(0,0,128)',
                        data: [numberOfBuil[0], numberOfBuil[1], numberOfBuil[2], numberOfBuil[3], numberOfBuil[4], numberOfBuil[5]]
                    }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: 'TOP 5 PRODUCTS',
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
                data: { labels: [jsVariable[0], jsVariable[1], jsVariable[2], jsVariable[3], jsVariable[4], jsVariable[5]],
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: [
                'rgba(255, 99, 132)',
                'rgba(54, 162, 235)',
                'rgba(255, 206, 86)',
                'rgba(75, 192, 192)',
                'rgba(153, 102, 255)',
                'rgba(255, 159, 64)'
            ],
                        borderColor: [
                'rgba(255, 99, 132)',
                'rgba(54, 162, 235)',
                'rgba(255, 206, 86)',
                'rgba(75, 192, 192)',
                'rgba(153, 102, 255)',
                'rgba(255, 159, 64)'
            ],
                        data: [10, 20, 30, 15, 20, 5]
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
                type: 'line',
                // The data for our dataset
                data: {
                    labels: ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"],
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

    <%--<br/>--%>

</asp:Content>
