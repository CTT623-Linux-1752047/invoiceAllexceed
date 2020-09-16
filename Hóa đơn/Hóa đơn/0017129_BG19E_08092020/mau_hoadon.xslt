<?xml version="1.0" encoding="utf-8"?><!-- Edited by XMLSpyÂ® --><!--<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxml="urn:schemas-microsoft-com:xslt">
<xsl:template match="/">--><xsl:stylesheet version="1.0" xmlns:hnx="http://www.w3.org/2000/09/xmldsig#" xmlns:exsl="http://exslt.org/common" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ex="http://exslt.org/dates-and-times" xmlns:inv="http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1" extension-element-prefixes="ex"><xsl:output method="html" cdata-section-elements="script" indent="no" omit-xml-declaration="yes" /><xsl:template match="inv:invoice"><div style="page-break-inside: avoid "><html lang="en" xmlns="http://www.w3.org/1999/xhtml"><head><meta charset="utf-8" /><title><xsl:value-of select="inv:invoiceData/inv:invoiceName" /></title><meta http-equiv="X-UA-Compatible" content="IE=Edge" /><style type="text/css">
 .line{border-top:1px solid #0065b7;margin:3px 0 !important;line-height:3px !important}
                canvas{display:inline-block}html{font-size:100%}i{font-size:13px}input{margin:0;vertical-align:middle}tr{page-break-inside:avoid}
                p{orphans:0;widows:3}
                body{margin:0;font-family:Times New Roman;width:100%}p{margin:0 0 5px}.text-left{text-align:left !important}
                .text-right{text-align:right !important}.text-center{text-align:center !important}
                legend{display:block;width:100%;padding:0;color:#333;border-width:0 0 1px;border-style:none none solid;border-color:-moz-use-text-color -moz-use-text-color #e5e5e5;-moz-border-top-colors:none;-moz-border-right-colors:none;-moz-border-bottom-colors:none;-moz-border-left-colors:none;border-image:none}
                input{font-size:14px;font-weight:400;line-height:20px;font-family:"Helvetica Neue",Helvetica,Arial,sans-serif;width:206px;margin-left:0}
                .container {
                width: 720px;
						<!--height: 980px;-->
                font-size: 14px;
                line-height: 24px;
                font-family: Times New Roman;
                padding: 0px;
                border-radius: 0px;
                margin: 0 auto;
                border: 0px solid #0065b7;

                position: relative;
                display: table;
                color:#0065b7;
                }

                .invName{text-align:center;font-size:22px;line-height:25px;font-weight:700;margin:0 0 3px;text-transform:uppercase}
                .row {
                width: 100%;
                margin: 0;
                padding: 0;
                clear: both;
                display: table;
                }

                .row .col1, .row .col2, .row .col3, .row .col4, .row .col5, .row .col6, .row .col7, .row .col8, .row .col9, .row .col10, .row .col11, .row .col12, .row .col13, .row .col14, .row .col15, .row .col16, .row .col17, .row .col18, .row .col20 {
                display: block;
                float: left;
                padding: 0;
                margin: 0;

                }
                .row:after{clear:both}.row:after,.row:before{content:"";display:table;line-height:0}
                .row .col1 {
                width: 5%;
                }                    .row .col2 {
                width: 10%;
                }                    .col3 {
                width: 15%;
                }                    .col4 {
                width: 20%;
                }                    .col5 {
                width: 25%;
                }                    .col6 {
                width: 30%;
                }                    .col7 {
                width: 35%;
                }                    .col8 {
                width: 40%;
                }                    .col9 {
                width: 45%;
                }                    .col10 {
                width: 50%;
                }                    .col11 {
                width: 55%;
                }                    .col12 {
                width: 60%;
                }                    .col13 {
                width: 65%;
                }                    .col14 {
                width: 70%;
                }                    .col15 {
                width: 75%;
                }                    .col16 {
                width: 80%;
                }                    .col17 {
                width: 85%;
                }                    .col18 {
                width: 90%;
                }                    .col19 {
                width: 95%;
                }                    .col20 {
                width: 100%;
                }        
						<!--Css add them ko danh cho multi page-->
                .table {border-spacing:0;width:100%;margin-left:px;margin-top:0px;border-top:1px solid #0065b7;border-bottom:0px solid #0065b7;font-size:14px;color:#0065b7;}
                .table {border-style:solid solid solid solid;border-width:1px 0px 0px 0px; }
                .table th{padding:2px;text-align:center;font-size:12px}
                .table th{border-bottom:1px solid #0065b7;font-weight:700;border-left:1px solid #0065b7;}
                .table th:last-child{border-right:1px solid #0065b7}
                .table tbody tr th:last-child{border-right:0px solid #0065b7}
                .table tbody tr th:first-child{border-left:0px solid #0065b7}
                .table th{line-height:17px}


                .table td{padding:2px;text-align:left;vertical-align:top;border-left:1px solid #0065b7}
                .table td{border-top:1px solid #DDD;font-size:14px}
                .table tbody tr td:last-child{border-right:0px solid #0065b7}
				 <!-- .table tbody tr:last-child{border-bottom:1px solid #0065b7} -->
                .table tbody tr td:first-child{border-left:0px solid #0065b7}
						<!-- .table tbody tr:last-child &gt; td{border-top:1px solid #0065b7;} -->


                .table-all-border {border-spacing:0;width:100%}
                .table-all-border td{padding:2px;border-left:0px solid #0065b7;border-top:1px solid #0065b7}
                .table-all-border tbody tr td:last-child{border-right:1px solid #0065b7}
                .table-all-border tbody tr:last-child &gt; td{border-top:1px solid #0065b7;}
                .table td{line-height:24px}
                table{max-width:100%;background-color:transparent;border-collapse:collapse;border-spacing:0;}

                .abcdef{
                border: 3px none #0065b7000;
                font-weight: bold;
                font-size: 40px;
                position: absolute;
                top: 490px;
                left: 69px;
                width: 600px;
                background: none;
                z-index: -1;

                }
                .next-page { page-break-inside:always;  page-break-after:always}

                .TitleHD {
                text-transform: uppercase;
                font-size: 11px;
                font-weight: 900;
                font-family:time new roman;
                }
                .nom{
                font-weight: normal !important;
                }
                .boderTop{
                border-top: 1px solid #0065b7 !important;
                }
                .boderBot{
                border-bottom: 1px solid #0065b7 !important;
                }
                .boderLe{
                border-left: 1px solid #0065b7 !important;
                }
                .boderRi{
                border-right: 1px solid #0065b7 !important;
                }
                .textThaiSon{
                position: absolute;
                top: 250px;
                display: block;
                right:-14px;
                font-style: italic;
                font-size: 11px;
                }
                .phathanh{
                position:absolute;
                opacity:0.8;
                filter:alpha(opacity=100);
                top:297px;
                left:180px;
                width:300px;
                height:auto;
                z-index:1;
                background: none;
                }
                .logo{}
                .tbks{width:100%;}
                .tbks td{height:57.5px}
                .textcd{height:70px;line-height:17px;margin-top:3px}
                .kysoban{margin: 0 auto; border: solid 1px #ff0000; padding: 3px; color: #ff0000; position: relative; z-index: 1; font-size: 11px; max-width: 270px; text-align: left;line-height: 14px}
                        .maginHeader{display: table;  width: 100%;margin: 0;padding-top:0px;clear: both; height:0px;color:#fff;border-top:0px solid #0065b7;margin-bottom: 0px}
                        .maginHeaderTop{display: table;  width: 100%;margin: 0;padding-top:0px;clear: both; height:0px;color:#fff;border-top:0px solid #0065b7;margin-bottom: 35px}
                        .maginHeaderMin{display: table;  width: 100%;margin: 0;padding-top:10px;clear: both; height:10px;color:#fff;}
                        .border2{ border-left:1px solid #0065b7; border-right:1px solid #0065b7;padding:0px;margin-right:0px;display:table;width:99.8%;}
                        .boderNew{border-width:1px 0px 0 0px;border-style:solid}
                        .fixTable{ color:#0065b7;border-color: #0065b7;margin:auto;
                        width:100%;font-size:14px;background-color:transparent;border-collapse:collapse;border-spacing:0;
						border-style: solid; border-width:0 1px 1px 1px;
                        -moz-border-top-colors:none;-moz-border-right-colors:none;-moz-border-bottom-colors:none;-moz-border-left-colors:none;border-image:none;border-collapse:separate;border-radius:0px
                        }
                        .fixTable td{padding:2px;line-height:22px}
                        .fixTable tbody tr td{border-left:1px solid #0065b7}
                        .fixTable tbody tr:first-child td{border-left:none}
                        .fixTable tbody tr td:first-child{border-left:none}
                        .breackPage {
                        page-break-after: always;
                        }
                        .wallperBg{
                        position: relative;
                        }
					</style><!-- <thaison>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</thaison> --><script><xsl:text disable-output-escaping="yes"><![CDATA[
							function loadData() {
							var mainElement = document.getElementById("main");
							//Khai bao max height của mỗi page tùy thuộc vào khổ in px
							//nếu in A4
							// cần sửa in html giá trị là 1045, in pdf giá trị là 1070, in html sửa margin-top của class maginHeaderTop về 0
							var heightA4 = 1045; 

							//get string html cần thiết

							var headerHtmlString = document.getElementById("headerFix").innerHTML;
							var bgString = document.getElementById("hinhNen").innerHTML;
							var headerTableHtmlString = (document.getElementById("tableHiden").getElementsByTagName("thead"))[0].innerHTML;

							var indexRow = 0; //biến duyệt qua các dòng trong bảng hàng hóa
							var countPage = 1;// biến đếm số trang khi breack ra
							var maxHeightTable = 0;

							var listRow = document.getElementById("tableHiden").getElementsByTagName("tbody")[0].getElementsByTagName("tr");
							
							//add fix header vào mỗi trang
							var tempHeader = document.createElement("div");
							tempHeader.className="border2";
							tempHeader.innerHTML = headerHtmlString;
							mainElement.appendChild(tempHeader);
							
							//đánh số trang
							var displayPageString = "<div class='row displayPage text-right' >Trang " + countPage + "/<span class='maxPage'></span></div>";
							var displayPageElement = document.createElement("div");
							displayPageElement.innerHTML = displayPageString;
							displayPageElement.className = "border2";
							displayPageElement.setAttribute("id", ("soPage" + countPage));
							//mainElement.appendChild(displayPageElement);
							var isPH =  document.getElementById("imgPH");
							do {
								//get max heigh cho moi table
								if (countPage != 1) {
									var hHeader = tempHeader.offsetHeight + displayPageElement.offsetHeight;
									maxHeightTable = heightA4 - hHeader;
								}
								else
								{
									var hHeader = tempHeader.offsetHeight + displayPageElement.offsetHeight;
									maxHeightTable = heightA4 - hHeader;
								}
								//alert (maxHeightTable);

								//add table
								var tempTable = document.createElement("table");
								tempTable.setAttribute("id", ("table" + countPage));
								tempTable.className = "table table-bordered";

								//add tiêu đề bảng hàng hóa
								var theadTemp = document.createElement("thead");
								theadTemp.innerHTML = headerTableHtmlString;
								tempTable.appendChild(theadTemp);

								var tbodyTemp = document.createElement("tbody");
								tempTable.appendChild(tbodyTemp);

								var tempDiv = document.createElement("div");
								tempDiv.className="border2";
								tempDiv.appendChild(tempTable);
								mainElement.appendChild(tempDiv);

								//Hiển thị thông tin số trang (trang 1/ tong so..)
								if( countPage == 1)
								   if (isPH)
									var displayPageString = "<div class='row displayPage text-right' >Trang 1/Y (từ trang số 2 có giá trị: tiep theo trang truoc - trang X/Y) </div>";
								   else
									var displayPageString = "<div class='row displayPage text-right' >Trang " + countPage + "/<span class='maxPage'></span></div>";
								else
									var displayPageString = "<div class='row displayPage text-right' >tiếp theo trang trước - trang " + countPage + "/<span class='maxPage'></span></div>";
								var displayPageElement = document.createElement("div");
								displayPageElement.innerHTML = displayPageString;
								displayPageElement.className = "";
								displayPageElement.setAttribute("id", ("soPage" + countPage));
								
								for (var i = indexRow; i < listRow.length; i++) {
									var tr = document.createElement("tr");
									tr.setAttribute("id", ("tr_so" + indexRow));
									tr.innerHTML = listRow[i].innerHTML;
									tbodyTemp.appendChild(tr);
									var heightTable = tempTable.offsetHeight;
									if(countPage == 1)
									{
										if (heightTable >= maxHeightTable - 24) 
										{
											var elem = document.getElementById("tr_so" + indexRow);
											elem.parentElement.removeChild(elem);
											
											var divMagin = document.createElement("div");
											divMagin.className = "maginHeader";
											divMagin.innerHTML="";
											mainElement.appendChild(divMagin);
											mainElement.appendChild(displayPageElement);
											
											var divBreack = document.createElement("div");
											divBreack.className = "breackPage";
											mainElement.appendChild(divBreack);
											
											var divMagin = document.createElement("div");
											divMagin.className = "maginHeaderTop";
											divMagin.innerHTML="";
											mainElement.appendChild(divMagin);

											var bgElement = document.createElement("div");
											bgElement.className = "wallperBg";
											bgElement.innerHTML = bgString;
											mainElement.appendChild(bgElement);

											//add fix header vào mỗi trang
											var tempHeader = document.createElement("div");
											tempHeader.className="border2";
											tempHeader.innerHTML = headerHtmlString;
											mainElement.appendChild(tempHeader);

											break;
										}
									}
									else
									{
										if (heightTable >= maxHeightTable) 
										{
											var elem = document.getElementById("tr_so" + indexRow);
											elem.parentElement.removeChild(elem);

											var divMagin = document.createElement("div");
											divMagin.className = "maginHeader";
											divMagin.innerHTML="";
											mainElement.appendChild(divMagin);
											mainElement.appendChild(displayPageElement);

											var divBreack = document.createElement("div");
											divBreack.className = "breackPage";
											mainElement.appendChild(divBreack);

											var divMagin = document.createElement("div");
											divMagin.className = "maginHeaderTop";
											divMagin.innerHTML="";
											mainElement.appendChild(divMagin);

											var bgElement = document.createElement("div");
											bgElement.className = "wallperBg";
											bgElement.innerHTML = bgString;
											mainElement.appendChild(bgElement);

											//add fix header vào mỗi trang
											var tempHeader = document.createElement("div");
											tempHeader.className="border2";
											tempHeader.innerHTML = headerHtmlString;
											mainElement.appendChild(tempHeader);
											break;
										}
									}
									if (indexRow === listRow.length) {
									console.log("het tr ");
									break;
									}
									indexRow++;
								}
								var heightTablenew = heightTable;
								countPage++;
								var demtrang = countPage-1;
								//alert (heightTablenew);
								console.log('====' + indexRow);
							}
							while (indexRow < listRow.length);
							//add fix footer
							var elmentFoote = document.getElementById("footerFix");
							mainElement.appendChild(elmentFoote);
							mainElement.appendChild(displayPageElement);
							heightFooter = elmentFoote.clientHeight;
							var break1;
							break1 = 0;
							//tinh toan xem them footer vao thi co bi sang trang nua ko
							if ((maxHeightTable - heightTable)  < heightFooter) 
							{
								break1 = 1 ;
								//alert(heightTable +"awe");
								var divMagin = document.createElement("div");
								divMagin.className = "maginHeader";
								divMagin.innerHTML="";
								elmentFoote.parentNode.insertBefore(divMagin, elmentFoote);
								elmentFoote.parentNode.insertBefore(displayPageElement, elmentFoote);

								//add break trang
								var divBreack = document.createElement("div");
								divBreack.className = "breackPage";
								elmentFoote.parentNode.insertBefore(divBreack, elmentFoote);
								
								//add margintop
								var divMaginTop = document.createElement("div");
								divMaginTop.className = "maginHeaderTop";
								divMaginTop.innerHTML="";
								elmentFoote.parentNode.insertBefore(divMaginTop, elmentFoote);

								//add hình nền + rightnote
								var bgElement = document.createElement("div");
								bgElement.className = "wallperBg";
								bgElement.innerHTML = bgString;
								elmentFoote.parentNode.insertBefore(bgElement, elmentFoote);

								//add fix header vào mỗi trang
								var tempHeader = document.createElement("div");
								tempHeader.innerHTML = headerHtmlString;
								tempHeader.className="border2";
								elmentFoote.parentNode.insertBefore(tempHeader, elmentFoote);
								
								//Hiển thị thông tin số trang (trang 1/ tong so..)
								var displayPageString = "<div class='row displayPage text-right' >tiep theo trang truoc - trang " + countPage + "/<span class='maxPage'></span></div>";
								var displayPageElement = document.createElement("div");
								displayPageElement.innerHTML = displayPageString;
								displayPageElement.className = "";
								displayPageElement.setAttribute("id", ("soPage" + countPage));
								mainElement.appendChild(displayPageElement);
								
								countPage++;
							}
							
							countPage--;
							var listMaxPage = document.getElementsByClassName("maxPage");
							for (var y = 0; y < listMaxPage.length; y++) 
							{
								listMaxPage[y].innerHTML = countPage;
							}
							//alert (heightDongH);
							for (var z = 1; z <= countPage; z++)
							{
								var tableTemp = document.getElementById("table" + z);
								var heightTable = tableTemp.offsetHeight;  // độ dài bảng hàng hóa
								var heightHeader = tempHeader.offsetHeight; // độ dài thông tin bên bán và bên mua
								var marginTop = heightA4;
								// cần sửa, lấy theo giá trị của 1 row hàng hóa
								var heightDongH = 29;
								var heightSoTrang = displayPageElement.offsetHeight;// độ dài số trang
								var soDong = 0;
								// cần sửa, lấy theo số cột trên bảng hàng hóa
								var soTD = "<td style='line-height:24px'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
								if (countPage == 1 )
								{
									heightDu = heightA4 - heightFooter - heightTable - heightHeader - heightSoTrang;
									soDong = Math.floor(heightDu / heightDongH) ;
									 
									if (soDong > 0)
									{
										var trEnd = document.getElementById("tr_so" + (indexRow - 1));
										for (var z = 0; z < soDong; z++) {
										var trT = document.createElement("tr");
										trT.innerHTML = soTD;
										tbodyTemp.appendChild(trT);
										}
									}
								}
								else
								{
									if (z == 1)
									{
										if( countPage >1)
										{
											if ( break1 !=1)
											{
												var heightTable = tempTable.offsetHeight;
												var heightHeader = tempHeader.offsetHeight;
												//heightFooter
												heightDu = heightA4 - heightFooter - heightTable - heightHeader - heightSoTrang;
												soDong = Math.floor(heightDu / heightDongH) ;
												 
											}
											else
											{
												heightDu = heightA4  - heightHeader - heightTable - heightSoTrang;
												soDong = Math.floor(heightDu / heightDongH) ;
												  
												//add table
												var tempTable = document.createElement("table");
												tempTable.setAttribute("id", ("table" + countPage));
												tempTable.className = "table table-bordered";
												
												var theadTemp = document.createElement("thead");
												theadTemp.innerHTML = headerTableHtmlString;
												tempTable.appendChild(theadTemp);

												var tbodyTemp = document.createElement("tbody");
												tempTable.appendChild(tbodyTemp);

												var tempDiv = document.createElement("div");
												tempDiv.className="border2";
												tempDiv.appendChild(tempTable);
												mainElement.appendChild(tempDiv);
												elmentFoote.parentNode.insertBefore(tempDiv, elmentFoote);

												heightDu = heightA4 - heightFooter - heightHeader - tempDiv.offsetHeight - heightSoTrang;
												soDong = Math.floor(heightDu / heightDongH) ;
												 
											}
										}
										else
										{
											heightDu = heightA4 - heightFooter - heightHeader - heightTable - heightSoTrang;
											soDong = Math.floor(heightDu / heightDongH) ;
											//alert (soDong );
											 
										}
									}
									else if (z == countPage)
									{
										if( break1 == 1)
										{
											heightDu = heightA4 - heightFooter - heightHeader - heightTable - heightSoTrang;
											soDong = Math.floor(heightDu / heightDongH) ;
											 
										}
										else
										{
											heightDu = heightA4 - heightTable - heightFooter - heightHeader  - heightSoTrang;
											soDong = Math.floor(heightDu / heightDongH) ;
											//alert (soDong );
											 
										}
									}
									else if(z < countPage && z >1)
									{
										heightDu = heightA4 - heightTable - heightHeader - heightSoTrang;
										soDong = Math.floor(heightDu / heightDongH) ;
										 
									}
								}
							}
							// hoangnx
							var elementPageEnd = document.getElementById("soPage" + countPage);
							mainElement.appendChild(elementPageEnd);
							// add padding cho số trang
							for (var z = 1; z <= countPage; z++)
							{
								var tableTemp = document.getElementById("table" + z);
								var heightTableNew = tableTemp.offsetHeight;
								var heightTable = tempTable.offsetHeight;
								var heightHeader = tempHeader.offsetHeight;
								var heightSoTrang = displayPageElement.offsetHeight;// độ dài số trang
								var marginTop = heightA4;
								var heightAll = heightFooter + heightTableNew + heightHeader + heightSoTrang;
								
								//alert( heightAll );
								if (typeof (tableTemp) != 'undefined' && tableTemp != null) 
								{
									marginTop = marginTop - tableTemp.clientHeight;
								}
								if (countPage == 1 )
								{
									marginTop = heightA4 - (heightHeader + heightTableNew + heightFooter + heightSoTrang);
									if(marginTop>0)
									{
										var pageEl = document.getElementById("soPage" + z).setAttribute("style", "padding-top: " + marginTop+"px !important");
										//alert("a");
									}
								}
								else
								{
									if (z == 1)
									{
										if( countPage >1)
										{
											if( break1 == 1)
											{
												marginTop = heightA4 - (heightTableNew + heightHeader + heightSoTrang);
												
												if(marginTop>0)
												{
													var pageEl = document.getElementById("soPage" + z).setAttribute("style", "padding-top: " + marginTop+"px !important");
												}
											}
											else
											{
												marginTop = heightA4 - (heightTableNew + heightHeader + heightSoTrang);
												if(marginTop>0)
												{
													var pageEl = document.getElementById("soPage" + z).setAttribute("style", "padding-top: " + marginTop+"px !important");
												}
											}
										}
										else
										{
										
										}
									}
									else if (z == countPage)
									{
										if( break1 == 1)
										{
											marginTop = heightA4 - heightFooter - heightHeader - heightTableNew - heightSoTrang;
											if(marginTop>0)
											{
												var pageEl = document.getElementById("textNote").setAttribute("style", "padding-top: " + marginTop+"px !important");
											}
										}
										else
										{
											marginTop = heightA4 - heightAll;
											if(marginTop>0)
											{
												var pageEl = document.getElementById("textNote").setAttribute("style", "padding-top: " + marginTop+"px !important");
											}
											
										}
									}
									else if(z < countPage && z >1)
									{
										marginTop = heightA4 - heightHeader - heightTableNew - heightSoTrang;
										if(marginTop>0)
										{
											var pageEl = document.getElementById("soPage" + z).setAttribute("style", "padding-top: " + marginTop+"px !important");
										}
									}
									else
									{
										marginTop = 0;
									}
								}
								//alert( marginTop );
							}
							document.getElementById('main').style.display = 'none';
							document.getElementById('main').style.display = 'table';
							}
							]]></xsl:text></script></head><body style="margin: 0; padding: 0" onload="loadData()"><xsl:variable name="ttdv" select="inv:invoiceData/inv:sellerLegalName" /><xsl:variable name="issuedDate" select="inv:invoiceData/inv:invoiceIssuedDate" /><xsl:variable name="nguyente" select="inv:invoiceData/inv:currencyCode" /><xsl:variable name="FullLoai" select="inv:invoiceData/inv:invoiceType" /><xsl:variable name="loaiHoaDon" select="substring($FullLoai, 1, 2)" /><xsl:variable name="signedDate" select="inv:invoiceData/inv:signedDate" /><xsl:variable name="phathanh" select="inv:invoiceData/inv:phatHanh" /><xsl:variable name="dateconvert" select="inv:viewData/inv:DateExchange" /><!--start main--><div id="main" class="container"><div id="hinhNen" class="wallperBg"><img class="abcdef" src="data:image/gif;base64,R0lGODlhxwKEAMQRAP7u7/729v3l5v/9/fzf4P3q6v7z8/3i4//7+//5+f3j5P709f7w8P3o6f7s7f7t7vzd3v///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH/C1hNUCBEYXRhWE1QPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxMzggNzkuMTU5ODI0LCAyMDE2LzA5LzE0LTAxOjA5OjAxICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ4bXAuZGlkOjAxMDYyNWIwLTcyNzgtYzc0My04ZjkwLTNmNjk5MmNmN2RiZCIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpGNUM5MDk0OTRDQzgxMUU3ODIzMkY0QUMzQjhGMUM2RSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDpGNUM5MDk0ODRDQzgxMUU3ODIzMkY0QUMzQjhGMUM2RSIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxNyAoV2luZG93cykiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpkODhhYjBjYy1jYjYyLWY5NGEtOGY0MS0xMWJkM2M5MmQ5NWEiIHN0UmVmOmRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDpj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" /><xsl:if test="inv:invoiceData/inv:phatHanh = 'true'"><img ID="imgPH" class="phathanh" src="data:image/gif;base64,R0lGODlhXgFeAbMPAKOjo/X19cLCwoWFhXBwcLi4uODg4NbW1o+Pj3p6eszMzK2trevr65mZmWZmZv///yH/C1hNUCBEYXRhWE1QPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS4zLWMwMTEgNjYuMTQ1NjYxLCAyMDEyLzAyLzA2LTE0OjU2OjI3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M2IChXaW5kb3dzKSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo0MjcyMEE1NDNGRkYxMUU2OTAyQ0EwN0JCMkVCRTJENSIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo0MjcyMEE1NTNGRkYxMUU2OTAyQ0EwN0JCMkVCRTJENSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOjQyNzIwQTUyM0ZGRjExRTY5MDJDQTA3QkIyRUJFMkQ1IiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjQyNzIwQTUzM0ZGRjExRTY5MDJDQTA3QkIyRUJFMkQ1Ii8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+Af/+/fz7+vn49/b19PPy8fDv7u3s6+rp6Ofm5eTj4uHg397d3Nva2djX1tXU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" /></xsl:if><!-- <img class="textThaiSon" style="width:15px" src=" data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAB4AAAXcCAYAAAA1KD66AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NDRGMzdCRDVGREIyMTFFOEJFQ0U4MkU2RkJCODZCOUYiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NDRGMzdCRDZGREIyMTFFOEJFQ0U4MkU2RkJCODZCOUYiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo0NEYzN0JEM0ZEQjIxMUU4QkVDRTgyRTZGQkI4NkI5RiIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo0NEYzN0JENEZEQjIxMUU4QkVDRTgyRTZGQkI4NkI5RiIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PrrwSYUAADEoSURBVHja7F3tddw2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"/> --></div><!--end main--></div><div style="display: none"><div id="headerFix"><div class="boderNew"><div class="row" style="padding-top: 5px"><!--<div class="col3"></div>--><div class="col5 text-center" style=""><b>TỔNG CÔNG TY <br /> VIỄN THÔNG MOBIFONE</b><img class="logo" style="width:175px;margin-top:6px" src="data:image/gif;base64,R0lGODlhLAE4APf/APH2+8Pa7EKJxOHt9gBcrZ/D4UmNxviqrO4rM+ry+CR1uT2Gwv729ix7vN3q9O0WH2KczfBESvq6vPaJje4jKwBbrPJVW9bl8pO73aPF4gtdrvvJy4Wz2QBYq/mxtO0YIP3g4azL5Qhksf3p6eXv9/r8/f3l5tHi8bHN5mui0OwMFPA8Q/RscvilqPeZnRRlsewUHMjd7v74+PNobRJps/3+/hlrtfzc3pq/34u22nKl0v/6+uwSGgBVqjB+vgBgruwPGBxyt/NmbE2TylSVyl2azAFjtPFOVHWp1DeAv/aRlQBUquwOF/f6/PaGifV5foVNcvV/g6fI5PijpusCC+/1+u82Pfm1uO0fJ+8xOebw9/j6/VKSyP7y8/R0efvLzfvQ0fz9/veVmPrFx73W6/rBw/kWG/zf4PJfZf7s7faMkPNkanqs1vWBhv709PJYXvT4/PzT1fzV1gZbrOwJEuzz+bjT6e85QfRwdQJWqwZervvT1DOAv4Gx1/rCxABSqLrU6f3i5PzZ2vehpOwOGA1gr1aSyfrGyDF6vO0VHgBMpv7u7/3r7Pmusfza3Gegz/vO0P7w8enx+FmXy/FRVgdZq9jn8zR9vvNiaPNdYusIEABUqfFITrXR6ANarEGGwuwNFSZ3u9ro8/zX2Wmez8DX6yBvt/JaYPecoHqp1ARXqu83Pk+Oxu0bJPA/RuwTG+80OwNYrP///wBeru0bI//+/lOUye0aIv/8/ABdrQBfr/7//wBfrv/9/QBZq+30+f7+/+wRGf3n6O0ZIewLFPb5/ABerf7v8O0aI+0XH/NhZvP3+/7z8//8/dzp9H+v1/q9wP7t7v7x8u0QF/vNz+4oL+4vNufw9/T4+83g7/739+0bIv3s7Xyr1KjH4uwHD45sjg9ns+0aIe0WHt/r9ftkZusMFP/9/it3u9Tk8Rhns66GnhNfro+324Kv1z1/v83g8P/5+f719ZrA3zB1uv/7+wJVq/xnavA4P0+Qx+rx+O0dJQ9isO0cJABgr////yH/C1hNUCBEYXRhWE1QPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxMzggNzkuMTU5ODI0LCAyMDE2LzA5LzE0LTAxOjA5OjAxICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxNyAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NzY1RDVERjYyQTRDMTFFNzlDRERERDEwNTRCMzAyNDAiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NzY1RDVERjcyQTRDMTFFNzlDRERERDEwNTRCMzAyNDAiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo3NjVENURGNDJBNEMxMUU3OUNEREREMTA1NEIzMDI0MCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo3NjVENURGNTJBNEMxMUU3OUNEREREMTA1NEIzMDI0MCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PgH//v38+/r5+Pf29fTz8vHw7+7t7Ovq6ejn5uXk4+Lh4N/e3dzb2tnY19bV1NPS0dDPzs3My8rJyMfGxcTDwsHAv769vLu6ubi3trW0s7KxsK+urayrqqmop6alpKOioaCfnp2cm5qZmJeWlZSTkpGQj46NjIuKiYiHhoWEg4KBgH9+fXx7enl4d3Z1dHNycXBvbm1sa2ppaGdmZWRjYmFgX15dXFtaWVhXVlVUU1JRUE9OTUxLSklIR0ZFRENCQUA/Pj08Ozo5ODc2NTQzMjEwLy4tLCsqKSgnJiUk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" /></div><div class="col10 text-center" style="line-height:19px"><div class="invName"><!--<xsl:value-of select="inv:invoiceData/inv:invoiceName" />-->
                                HÓA ĐƠN GIÁ TRỊ GIA TĂNG <br />(VAT INVOICE)
										</div><div><div><xsl:choose><xsl:when test="inv:invoiceData/inv:phatHanh='true'">
                                            Ngày      
                                            tháng      
                                            năm 
													</xsl:when><xsl:otherwise>
                                            Ngày  <xsl:value-of select="substring($issuedDate, 9, 2)" />
                                            tháng  <xsl:value-of select="substring($issuedDate, 6, 2)" />
                                            năm  <xsl:value-of select="substring($issuedDate, 1, 4)" /><!--<xsl:value-of select="concat('Ngày ', substring($issuedDate, 9, 2), ' tháng ', substring($issuedDate, 6, 2), ' năm ', substring($issuedDate, 1, 4))" />--></xsl:otherwise></xsl:choose></div><xsl:choose><xsl:when test="inv:viewData/inv:printFlag = 'true'"><i style="font-size:12px">(HÓA ĐƠN CHUYỂN ĐỔI TỪ HÓA ĐƠN ĐIỆN TỬ)</i></xsl:when><xsl:otherwise><!--<xsl:if test="inv:viewData/inv:printFlag = 'false'">--><i style="font-size:12px">(BẢN THỂ HIỆN CỦA HÓA ĐƠN ĐIỆN TỬ)</i><!--</xsl:if>--></xsl:otherwise></xsl:choose></div></div><div class="col5 text-left" style="">
                            Mẫu số<i> (Form)</i>: <b><xsl:value-of select="inv:invoiceData/inv:templateCode" /></b><br />
                            Ký hiệu<i> (Serial No)</i>: <b><xsl:value-of select="inv:invoiceData/inv:invoiceSeries" /></b><br />
                            Số<i> (No)</i>: <span style="color:red ;font-size:24px"><xsl:choose><xsl:when test="inv:invoiceData/inv:phatHanh = 'true'">
													0000000
												</xsl:when><xsl:otherwise><xsl:value-of select="inv:invoiceData/inv:invoiceNumber" /></xsl:otherwise></xsl:choose></span><br /></div></div><div class="row boderTop"><div style="padding-left:5px"><div class="">
                                Đơn vị bán hàng<i> (Sale company)</i>: <span class="TitleHD headContent" style="font-size:11px"><xsl:value-of select="inv:invoiceData/inv:sellerLegalName" /></span></div><div class="">
                                Địa chỉ <i> (Address)</i>: 
											<xsl:value-of select="inv:invoiceData/inv:sellerAddressLine" /></div><div class="">
                                Số tài khoản<i> (Account code)</i>: 
											<xsl:value-of select="inv:invoiceData/inv:sellerBankAccount" />
									   Tại ngân hàng:	<span style="font-size:12px"><xsl:value-of select="inv:invoiceData/inv:sellerBankName" /></span></div><div class="col10">
                                Số điện thoại <i> (Tel)</i>: 
											<xsl:value-of select="inv:invoiceData/inv:sellerPhoneNumber" /></div><div class="col10">
                                Mã số thuế <i> (Tax code)</i>: <span style="font-weight:700;letter-spacing: 4px;font-size:13px"><xsl:value-of select="inv:invoiceData/inv:sellerTaxCode" /></span></div></div></div><div class="row"><xsl:choose><xsl:when test="inv:invoiceData/inv:adjustmentType = '3'"><div class="col20" style="padding-bottom:5px"><b>Thay thế cho hóa đơn điện tử số: </b><span class="border"><xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" /></span><br /></div></xsl:when><xsl:when test="inv:invoiceData/inv:adjustmentType = '5' and inv:invoiceData/inv:originalInvoiceId != ''"><div class="col20" style="padding-bottom:5px"><b>Điều chỉnh cho hóa đơn điện tử số: </b><span class="border"><xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" /></span><br /></div></xsl:when><xsl:when test="inv:invoiceData/inv:adjustmentType = '7' and inv:invoiceData/inv:originalInvoiceId != ''"><div class="col20" style="padding-bottom:5px"><b>Xóa bỏ cho hóa đơn điện tử số: </b><span class="border"><xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" /></span><br /></div></xsl:when></xsl:choose></div><div class="row"><div class="" style="padding-left:5px"><div>
                                Họ tên người mua hàng<i> (Customer's name)</i>: <b><xsl:value-of select="inv:invoiceData/inv:buyerDisplayName" /></b></div><div>
                                Tên đơn vị<i> (Company)</i>: <b><xsl:value-of select="inv:invoiceData/inv:buyerLegalName" /></b><br /></div><div>
                                Địa chỉ<i> (Address)</i>: <b><xsl:value-of select="inv:invoiceData/inv:buyerAddressLine" /></b></div><div>
                                Số tài khoản <i>(Account code)</i>: <b><xsl:value-of select="inv:invoiceData/inv:buyerBankAccount" /></b></div><div class="col10">
                                Hình thức thanh toán <i>(Kind of Payment)</i>:
											<xsl:for-each select="inv:invoiceData/inv:payments/inv:payment"><b><xsl:value-of select="inv:paymentMethodName" /></b></xsl:for-each></div><div class="col10">
                                Mã số thuế <i>(Tax code)</i>: <b><xsl:value-of select="inv:invoiceData/inv:buyerTaxCode" /></b></div></div></div><!--<hr class="hrblack"></hr>--></div></div><div style="display:none;line-height:1px; "><table id="tableHiden" style=""><thead class="text-center"><tr class="thead" style="text-transform: uppercase;"><th style="border-left:0px;width:28px">
                                    STT<div class="nom">

                                        (No)

											</div></th><th style="width: ;">
                                    Tên hàng hóa, dịch vụ<div class="nom">

                                        (DESCRIPTION)

											</div></th><th style="width: 55px;">
                                    ĐVT<div class="nom">

                                        (Unit)

											</div></th><th style="width: 55px;">
                                    Số lượng<div class="nom">

                                        (Q'ty)

											</div></th><th style="width: 70px;">
                                    Đơn giá<div class="nom">

                                        (Unit price)

											</div></th><th style="width: 110px;">
                                    Thành tiền<div class="nom">

                                        (Amount)

											</div></th><th style="width: 39px;">
                                    Thuế suất<div class="nom">

                                        (%) (VAT)

											</div></th><th style="width: 90px;">
                                    Tiền thuế<div class="nom">

                                        (VAT AMOUNT)

											</div></th><th style="width: 110px;border-right:none">
                                    Cộng<div class="nom">

                                        (TOTAL)

											</div></th></tr><tr class="thead"><td class="text-center boderBot">A</td><td class="text-center boderBot">B</td><td class="text-center boderBot">C</td><td class="text-center boderBot">1</td><td class="text-center boderBot">2</td><td class="text-center boderBot">3 = 1 * 2</td><td class="text-center boderBot">4</td><td class="text-center boderBot">5 = 3 * 4</td><td class="text-center boderBot">6 = 3 + 5</td></tr></thead><tbody><xsl:choose><xsl:when test="$phathanh='true'"></xsl:when><xsl:otherwise><xsl:for-each select="inv:invoiceData/inv:items/inv:item"><xsl:sort select="inv:unitPrice" data-type="number" /><tr><xsl:choose><xsl:when test="inv:lineNumber =''"><td class="text-center">
                             
															</td></xsl:when><xsl:when test="inv:lineNumber !=''"><td class="text-center"><xsl:value-of select="position()" /></td></xsl:when></xsl:choose><td><xsl:choose><xsl:when test="../../inv:adjustmentType = '5' or ../../inv:adjustmentType = '9'"><xsl:choose><xsl:when test="inv:isIncreaseItem = '' or inv:isIncreaseItem = 'true'">
                                                        Điều chỉnh tăng: 
																	</xsl:when><xsl:otherwise>
                                                        Điều chỉnh giảm: 
																	</xsl:otherwise></xsl:choose></xsl:when></xsl:choose><xsl:value-of select="inv:itemName" /><xsl:choose><xsl:when test="inv:vatPercentage = '-1' "><!--  (không chịu thuế) --></xsl:when><xsl:when test="inv:vatPercentage = '-2' "><!--  (không kê khai nộp thuế) --></xsl:when></xsl:choose></td><td class="text-center"><xsl:value-of select="inv:unitName" /></td><td class="text-right" style="font-size:13px"><xsl:if test="inv:quantity != ''"><xsl:value-of select="format-number(inv:quantity,'##.##0,##','number')" /></xsl:if></td><td class="text-right" style="font-size:13px"><xsl:if test="inv:unitPrice != ''"><xsl:value-of select="format-number(inv:unitPrice,'##.##0,##','number')" /></xsl:if></td><td class="text-right" style="font-size:13px"><xsl:if test="inv:itemTotalAmountWithoutVat != ''"><xsl:choose><xsl:when test="normalize-space(inv:itemTotalAmountWithoutVat) &lt; 0"><xsl:value-of select="format-number( (inv:itemTotalAmountWithoutVat) * (-1),'##.##0,##','number')" /></xsl:when><xsl:otherwise><xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0,##','number')" /></xsl:otherwise></xsl:choose></xsl:if></td><td class="text-right" style="font-size:13px"><xsl:choose><xsl:when test="inv:vatPercentage = '-1' "><!-- (không chịu thuế)-->\
															</xsl:when><xsl:when test="inv:vatPercentage = '-2' "><!-- (không kê khai nộp thuế)--> \
															</xsl:when><xsl:otherwise><xsl:if test="inv:vatPercentage != ''"><xsl:value-of select="format-number(inv:vatPercentage,'##.##0,##','number')" /></xsl:if></xsl:otherwise></xsl:choose></td><td class="text-right" style="font-size:13px"><xsl:choose><xsl:when test="inv:vatPercentage = '-1' ">
                                \
															</xsl:when><xsl:when test="inv:vatPercentage = '-2' and inv:MaNhom = 'KM'">
                                \
															</xsl:when><xsl:otherwise><xsl:if test="inv:vatAmount != ''"><xsl:choose><xsl:when test="normalize-space(inv:vatAmount) &lt; 0"><xsl:value-of select="format-number( (inv:vatAmount) * (-1),'##.##0,##','number')" /></xsl:when><xsl:otherwise><xsl:value-of select="format-number(inv:vatAmount,'##.##0,##','number')" /></xsl:otherwise></xsl:choose></xsl:if></xsl:otherwise></xsl:choose></td><td class="text-right" style="font-size:13px"><xsl:choose><xsl:when test="inv:itemTotalAmountWithoutVat != ''  and inv:vatAmount != ''"><xsl:choose><xsl:when test="normalize-space(inv:itemTotalAmountWithoutVat + inv:vatAmount) &lt; 0"><xsl:value-of select="format-number( (inv:itemTotalAmountWithoutVat + inv:vatAmount) * (-1),'##.##0,##','number')" /></xsl:when><xsl:otherwise><xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat + inv:vatAmount,'##.##0,##','number')" /></xsl:otherwise></xsl:choose><!-- <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat + inv:vatAmount ,'##.##0,##','number')" /> --></xsl:when><xsl:otherwise><xsl:if test="inv:itemTotalAmountWithoutVat != ''"><xsl:choose><xsl:when test="normalize-space(inv:itemTotalAmountWithoutVat) &lt; 0"><xsl:value-of select="format-number( (inv:itemTotalAmountWithoutVat) * (-1),'##.##0,##','number')" /></xsl:when><xsl:otherwise><xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0,##','number')" /></xsl:otherwise></xsl:choose><!-- <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0,##','number')" /> --></xsl:if></xsl:otherwise></xsl:choose></td></tr></xsl:for-each></xsl:otherwise></xsl:choose><xsl:if test="inv:invoiceData/inv:exchangeRate !='' and inv:invoiceData/inv:exchangeRate !='1'"><tr><td /><td>Tỷ giá: <xsl:value-of select="format-number(inv:invoiceData/inv:exchangeRate,'##.##0,#####','number')" /> VND/<xsl:value-of select="$nguyente" /></td><td /><td /><td /><td /><td /><td /><td class="text-right"></td></tr></xsl:if><xsl:variable name="tygia"><xsl:choose><xsl:when test="inv:invoiceData/inv:exchangeRate !='' and inv:invoiceData/inv:exchangeRate !='1'">
                                        1
											</xsl:when><xsl:otherwise>
                                        0
											</xsl:otherwise></xsl:choose></xsl:variable><xsl:variable name="chietkhau"><xsl:choose><xsl:when test="inv:invoiceData/inv:discountAmount != '' and inv:invoiceData/inv:discountAmount != 0">
                                        1
											</xsl:when><xsl:otherwise>
                                        0
											</xsl:otherwise></xsl:choose></xsl:variable><!-- <xsl:if test="inv:invoiceData/inv:discountAmount != '' and inv:invoiceData/inv:discountAmount != 0"> --><!-- <tr> --><!-- <td class="text-center"> --><!-- </td> --><!-- <td nowrap="">Chiết khấu</td> --><!-- <td> --><!-- </td> --><!-- <td> --><!-- </td> --><!-- <td> --><!-- </td> --><!-- <td> --><!-- </td> --><!-- <td /> --><!-- <td /> --><!-- <td class="text-right"> --><!-- <xsl:value-of select="format-number(inv:invoiceData/inv:discountAmount,'##.##0,##','number')" /> --><!-- </td> --><!-- </tr> --><!-- </xsl:if> --><xsl:if test="inv:invoiceData/inv:invoiceNote != ''"><tr><td class="text-center"></td><td><xsl:value-of select="inv:invoiceData/inv:invoiceNote" /></td><td></td><td /><td /><td /><td class="text-right"></td><td class="text-right"></td><td class="text-right"></td></tr></xsl:if></tbody></table></div><div style="display:none"><div class="" id="footerFix"><table class="fixTable"><tbody><xsl:choose><xsl:when test="normalize-space(inv:invoiceData/inv:discountAmount) = '0'"></xsl:when><xsl:when test="normalize-space(inv:invoiceData/inv:discountAmount) &gt; 0"><tr><td class="text-center" style="border-top:1px solid #DDD"></td><td colspan="5" class="boderLe" style="border-top:1px solid #DDD; font-style:italic; font-size:12.7px">
												Chiết khấu thanh toán được hưởng: <xsl:value-of select="format-number(inv:invoiceData/inv:discountAmount,'##.##0,##','number')" />. Số tiền thực thanh toán: 
													<xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != ''"><xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT - inv:invoiceData/inv:discountAmount,'##.##0,##','number')" /></xsl:if></td><td colspan="" class="boderLe" style="border-top:1px solid #DDD; font-style:italic; font-size:13px"></td><td colspan="" class="boderLe" style="border-top:1px solid #DDD; font-style:italic; font-size:13px"></td><td colspan="" class="boderLe" style="border-top:1px solid #DDD; font-style:italic; font-size:13px"></td></tr></xsl:when></xsl:choose><tr><td colspan="" class="boderTop" style="border-left:0px;width:28px"> 
											</td><td colspan="" class="boderTop" style="width: 55px;border-left:0px;"> 
											</td><td colspan="" class="boderTop" style="width: 55px;border-left:0px;"> 
											</td><td colspan="" class="boderTop" style="width: ;border-left:0px;"> 
											</td><td colspan="" class=" boderTop text-right" style="width: 136px;border-left:0px;"><b>CỘNG (TOTAL):</b></td><td colspan="" class="boderTop text-right boderLe" style="width: 110px;"><xsl:if test="inv:invoiceData/inv:totalAmountWithoutVAT != ''"><xsl:choose><xsl:when test="normalize-space(inv:invoiceData/inv:discountAmount) &gt; 0"><b><xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT + inv:invoiceData/inv:discountAmount,'##.##0,##','number')" /></b></xsl:when><xsl:when test="normalize-space(inv:invoiceData/inv:totalAmountWithoutVAT + inv:invoiceData/inv:discountAmount) = '0'">
												 
												</xsl:when><xsl:otherwise><b><xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT,'##.##0,##','number')" /></b></xsl:otherwise></xsl:choose></xsl:if></td><td colspan="" class="boderTop boderLe" style="width: 39px;">         
											</td><td colspan="" class="boderTop text-right boderLe" style="width: 90px;"><xsl:if test="inv:invoiceData/inv:totalVATAmount != ''"><xsl:choose><xsl:when test="normalize-space(inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdown/inv:vatPercentage) = '-1' "><b>
														\
													</b></xsl:when><xsl:when test="normalize-space(inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdown/inv:vatPercentage) = '-2' "><b>
														0
													</b></xsl:when><xsl:otherwise><b><xsl:value-of select="format-number(inv:invoiceData/inv:totalVATAmount,'##.##0,##','number')" /></b></xsl:otherwise></xsl:choose></xsl:if></td><td rowspan="2" class=" boderTop text-right boderLe" style="width: 110px;"><xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != ''"><b><xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##.##0,##','number')" /></b></xsl:if></td></tr><tr><td colspan="8" class="text-right boderTop" style="border-left:"><div class="row"><div class="col20 text-right"><xsl:choose><xsl:when test="(inv:invoiceData/inv:adjustmentType = '5' or inv:invoiceData/inv:adjustmentType = '9') and inv:invoiceData/inv:totalAmountWithVAT != '0'"><xsl:choose><xsl:when test="inv:invoiceData/inv:isTotalAmountPos = '' or inv:invoiceData/inv:isTotalAmountPos = 'true'">
                                                            Điều chỉnh tăng: 
																	</xsl:when><xsl:otherwise>
                                                            Điều chỉnh giảm: 
																	</xsl:otherwise></xsl:choose></xsl:when><xsl:otherwise><b style="text-transform: uppercase;">Tổng cộng tiền thanh toán (Grand total):</b></xsl:otherwise></xsl:choose></div></div></td></tr><tr><td colspan="9" class="boderTop text-left" style="border-left:0px"><div class="row" style="text-transform:uppercase;height:48px"><b>
                                            Số tiền viết bằng chữ (sum in words):
														<!----><b><xsl:value-of select="inv:invoiceData/inv:totalAmountWithVATInWords" />.</b></b></div></td></tr><tr><td colspan="9" class="boderTop"><div class="text-left textcd" style=""><xsl:choose><xsl:when test="inv:viewData/inv:printFlag = 'true'"><div class="row" style="font-size:13px;line-height:16px"><div class="col5" style=""><p class="text-center"><b>Người thực hiện chuyển đổi</b><br />
                                            Converter
																		<br /><i style="font-style: italic;font-size:12px">(Ký, ghi rõ họ tên)</i><br /><i style="font-style: italic;">(Sign &amp; full name)</i></p></div><div class="col5" style=""><p class="text-center"><b>Người mua hàng </b><br />
                                            Buyer
																		<br /><i style="font-style: italic;font-size:12px">(Ký, ghi rõ họ tên)</i><br /><i style="font-style: italic">(Sign &amp; full name)</i></p></div><div class="col4" style=""><p class="text-center"><b>Người bán hàng </b><br />
                                            Saler
																		<br /><i style="font-style: italic;font-size:12px">(Ký, ghi rõ họ tên)</i><br /><i style="font-style: italic">(Sign &amp; full name)</i></p></div><div class="col6" style=""><p class="text-center"><b>Thủ trưởng đơn vị </b><br />
                                            Chief officer

																		<br /><i style="font-style: italic;font-size:12px">(Ký, đóng dấu, ghi rõ họ tên)</i><br /><i style="font-style: italic">(Sign, stamp &amp; full name)</i></p><xsl:choose><xsl:when test="inv:invoiceData/inv:phatHanh='true'"><a href="#" style="text-decoration:none;"><div id="kysoban" class="kysoban"><img style="border:none;position: absolute; z-index: -1; right: 30px; top:8px" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
                                                                Signature Valid <br />
                                                                Ký bởi: <span style="font-size:9px"><xsl:value-of select="//./inv:invoiceData/inv:sellerLegalName" /></span><br />Ký  
                                                                ngày:         /         /   
																				</div></a></xsl:when><xsl:otherwise><xsl:for-each select="hnx:Signature"><xsl:if test="@Id = 'seller'"><a href="#" style="text-decoration:none;"><div id="kysoban" class="kysoban" style=""><img style="border:none;position: absolute; z-index: -1; right: 30px; top:8px" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" /><span style="font-size:8px">   Signature Valid <br />
                                                                        Ký bởi:  <xsl:value-of select="//./inv:invoiceData/inv:sellerLegalName" /><br />Ký 
																								<xsl:value-of select="concat('ngày: ', substring($signedDate, 9, 2), '/', substring($signedDate, 6, 2), '/', substring($signedDate, 1, 4))" /></span></div></a></xsl:if></xsl:for-each></xsl:otherwise></xsl:choose></div></div></xsl:when><xsl:otherwise><div class="row"><div class="col10" style=""><p class="text-center"><b>Người mua hàng <i>(Customer)</i><br /></b>
                                Ký, ghi rõ họ tên<i>(Salesman's signature)</i><br /></p></div><div class="col10"><p class="text-center"><b>Người bán hàng <i>(Goods sold by)</i><br /></b>
                                Ký, đóng dấu, ghi rõ họ tên<i>(Salesman's signature)</i><br /></p></div></div></xsl:otherwise></xsl:choose></div><div class="row" style=""><table class="tbks"><tr><xsl:choose><xsl:when test="inv:viewData/inv:printFlag = 'true'"><td style="vertical-align:bottom;"><div class="row text-center" style=""><div class="col5" style=" color:#0065b7;font-size:11px"><br /><xsl:value-of select="inv:viewData/inv:userPrint" /> 
																				<div class="" style=" color:#0065b7;font-size:11px">
                                                        Ngày chuyển đổi: <xsl:choose><xsl:when test="inv:viewData/inv:DateExchange != ''"><xsl:value-of select="concat(substring($dateconvert, 9, 2),'/', substring($dateconvert, 6, 2),'/', substring($dateconvert, 1, 4))" /></xsl:when><xsl:otherwise>
                                                                    /    /20
																						</xsl:otherwise></xsl:choose></div></div></div></td></xsl:when><xsl:otherwise><td style="vertical-align:middle;"><div class="col10"><br /></div><div class="col10 text-center" style=""><xsl:choose><xsl:when test="inv:invoiceData/inv:phatHanh='true'"><a href="#" style="text-decoration:none;"><div id="kysoban" class="kysoban"><img style="border:none;position: absolute; z-index: -1; right: 30px; top:8px" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
                                                                Signature Valid <br />
                                                                Ký bởi:  <span style="font-size:9px"><xsl:value-of select="//./inv:invoiceData/inv:sellerLegalName" /></span><br />Ký  
                                                                ngày:         /         /   
																						</div></a></xsl:when><xsl:otherwise><xsl:for-each select="hnx:Signature"><xsl:if test="@Id = 'seller'"><a href="#" style="text-decoration:none;"><div id="kysoban" class="kysoban" style=""><img style="border:none;position: absolute; z-index: -1; right: 30px; top:8px" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
                                                                        Signature Valid <br />
                                                                        Ký bởi: <xsl:value-of select="//./inv:invoiceData/inv:sellerLegalName" /><br />Ký 
																									<xsl:value-of select="concat('ngày: ', substring($signedDate, 9, 2), '/', substring($signedDate, 6, 2), '/', substring($signedDate, 1, 4))" /></div></a></xsl:if></xsl:for-each></xsl:otherwise></xsl:choose></div></td></xsl:otherwise></xsl:choose></tr></table></div><div class="row" id="textNote"><div class="text-center row" style="line-height:18px"><div><xsl:choose><xsl:when test="inv:invoiceData/inv:phatHanh='true'">
                                    Mã nhận hóa đơn:                     tra cứu tại:
																	<a href="http://invoice.mobifone.vn/"><b>http://invoice.mobifone.vn</b></a></xsl:when><xsl:otherwise>
                                    Mã nhận hóa đơn:
																	<b><xsl:value-of select="inv:invoiceData/inv:delivery/inv:containerNumber" /></b> tra cứu tại: 
																	<!--<xsl:variable name="wtc" select="inv:invoiceData/UrlWebTraCuu" /><a href="{$wtc}"><xsl:value-of select="substring-before(substring-after(inv:invoiceData/UrlWebTraCuu, '://'), '/')" /></a>--><a href="http://invoice.mobifone.vn/"><b>http://invoice.mobifone.vn</b></a></xsl:otherwise></xsl:choose></div><i style="font-size: 12px;">
                            (Cần kiểm tra, đối chiếu khi lập, giao nhận hóa đơn)
														</i></div><!--<div class="text-center">Trang 1/Y (từ trang số 2 có giá trị: tiep theo trang truoc - trang X/Y)</div>--><input type="hidden" id="qrcodeContent"><xsl:attribute name="value"><xsl:value-of select="inv:controlData/inv:qrCodeData" /></xsl:attribute></input></div></td></tr></tbody></table></div></div></div></body></html></div></xsl:template><xsl:template match="text()" name="split"><xsl:param name="pText" select="inv:itemName" /><xsl:if test="string-length($pText)"><xsl:if test="($pText =.)"><br /></xsl:if><xsl:value-of select="substring-before(concat($pText,'::'),'::')" /><br /><xsl:call-template name="split"><xsl:with-param name="pText" select="substring-after($pText, '::')" /></xsl:call-template></xsl:if></xsl:template><xsl:template name="dummy-rows"><xsl:param name="how-many" select="0" /><xsl:if test="$how-many &gt; 0"><tr><td class="text-center">
                     
				</td><!--<td>
                  <xsl:value-of select="inv:itemCode"/>
                </td>--><td></td><td class="text-left"></td><td class="text-right"></td><td></td><td></td><td class="text-right"></td><td class="text-right"></td><td class="text-right"></td></tr><xsl:call-template name="dummy-rows"><xsl:with-param name="how-many" select="$how-many - 1" /></xsl:call-template></xsl:if></xsl:template><xsl:decimal-format name="number" decimal-separator="," grouping-separator="." /></xsl:stylesheet>