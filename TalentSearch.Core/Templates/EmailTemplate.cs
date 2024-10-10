using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentSearch.Core.Templates
{
	public static class EmailTemplate
	{
		public static string EmailSurveyTemplate(string _Name, string _Email, string _Phone, string _Identity)
		{
			return @"<html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8""><meta name=""viewport"" content=""width=device-width,initial-scale=1;""><meta name=""format-detection"" content=""telephone=no""><style>body{margin:0;padding:0;min-width:100%;width:100%!important;height:100%!important}a,body,div,p,table,td{-webkit-font-smoothing:antialiased;text-size-adjust:100%;-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;line-height:100%}table,td{mso-table-lspace:0;mso-table-rspace:0;border-collapse:collapse!important;border-spacing:0}img{border:0;line-height:100%;outline:0;text-decoration:none;-ms-interpolation-mode:bicubic}#outlook a{padding:0}.ReadMsgBody{width:100%}.ExternalClass{width:100%}.ExternalClass,.ExternalClass div,.ExternalClass font,.ExternalClass p,.ExternalClass span,.ExternalClass td{line-height:100%}@media all and (min-width:560px){.container{border-radius:10px;-webkit-border-radius:10px;-moz-border-radius:10px;-khtml-border-radius:10px}}a,a:hover{color:#127db3}.footer a,.footer a:hover{color:#999}</style><title>YP Talent Bank</title></head><body topmargin=""0"" rightmargin=""0"" bottommargin=""0"" leftmargin=""0"" marginwidth=""0"" marginheight=""0"" width=""100%"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;width:100%;height:100%;-webkit-font-smoothing:antialiased;text-size-adjust:100%;-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;line-height:100%;background-color:#f0f0f0;color:#000"" bgcolor=""#F0F0F0"" text=""#000000""><table width=""100%"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;width:100%"" class=""background""><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0"" bgcolor=""#F0F0F0""><table border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" width=""560"" style=""border-collapse:collapse;border-spacing:0;padding:0;width:inherit;max-width:560px"" class=""wrapper""><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;padding-top:20px;padding-bottom:20px""><div style=""display:none;visibility:hidden;overflow:hidden;opacity:0;font-size:1px;line-height:1px;height:0;max-height:0;max-width:0;color:#f0f0f0"" class=""preheader"">YP Talent Bank</div><img target=""_blank"" style=""text-decoration:none"" href=""#""><img border=""0"" vspace=""0"" hspace=""0"" src=""https://raw.githubusercontent.com/helmeyusopyp/talentbank/b6c2333d663bebb6c7c1368e36469a2959e64fc4/logo_full.svg"" width=""200"" height=""70"" alt=""Logo"" title=""Logo"" style=""color:#000;font-size:10px;margin:0;padding:0;outline:0;text-decoration:none;-ms-interpolation-mode:bicubic;border:none;display:block""></td></tr></table><table border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" bgcolor=""#FFFFFF"" width=""560"" style=""border-collapse:collapse;border-spacing:0;padding:0;width:inherit;max-width:560px"" class=""container""><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;font-size:24px;font-weight:700;line-height:130%;padding-top:25px;color:#000;font-family:sans-serif"" class=""header"">YP Talent Bank</td></tr><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-bottom:25px;padding-left:6.25%;padding-right:6.25%;width:87.5%;font-size:20px;font-weight:300;line-height:150%;padding-top:5px;color:#000;font-family:sans-serif"" class=""subheader"">Thank you for your registration!</td></tr><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-top:20px;width:100%;max-width:560px;background-color:#2596be;color:#fff;font-size:24px;margin:0;padding:0;outline:0;text-decoration:none;-ms-interpolation-mode:bicubic;border:none;display:block;font-family:sans-serif;padding-top:25px;"" class=""hero""><h3>" + _Name + @"</h3><h4>" + _Identity + @"<br/>" + _Phone + @"</h4><br/></td></tr><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;font-size:17px;font-weight:400;line-height:160%;padding-top:25px;color:#000;font-family:sans-serif"" class=""paragraph""><div style=""line-height:110%"">Stay tuned for exciting offerings and let's shape your future together!</div></td></tr><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;padding-top:25px"" class=""line""><hr color=""#E0E0E0"" align=""center"" width=""100%"" size=""1"" noshade=""noshade"" style=""margin:0;padding:0""></td></tr><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;font-size:17px;font-weight:400;line-height:160%;padding-top:20px;padding-bottom:25px;color:#000;font-family:sans-serif"" class=""paragraph"">Have a&nbsp;question? <a href=""mailto:info@yayasanpeneraju.com.my"" target=""_blank"" style=""color:#127db3;font-family:sans-serif;font-size:17px;font-weight:400;line-height:160%"">info@yayasanpeneraju.com.my</a></td></tr></table><table border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" width=""560"" style=""border-collapse:collapse;border-spacing:0;padding:0;width:inherit;max-width:560px"" class=""wrapper""><tr><td align=""center"" valign=""top"" style=""border-collapse:collapse;border-spacing:0;margin:0;padding:0;padding-left:6.25%;padding-right:6.25%;width:87.5%;font-size:13px;font-weight:400;line-height:150%;padding-top:20px;padding-bottom:20px;color:#999;font-family:sans-serif"" class=""footer"">Talent Bank © Yayasan Peneraju</td></tr></table></td></tr></table></body></html>";
		}

		public static string EmailActivation()
		{
			return @"
				<!DOCTYPE html>
				<html lang=""en"">
					<head>
						<base href=""""https://peneraju.org"" />
						<link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Inter:300,400,500,600,700"" />
						<link href=""https://peneraju.org/assets/plugins/global/plugins.bundle.css"" rel=""stylesheet"" type=""text/css"" />
						<link href=""https://peneraju.org/assets/css/style.bundle.css"" rel=""stylesheet"" type=""text/css"" />
					</head>
					<body id=""kt_body"" class=""app-blank"">
						<script>var defaultThemeMode = ""light""; var themeMode; if ( document.documentElement ) { if ( document.documentElement.hasAttribute(""data-bs-theme-mode"")) { themeMode = document.documentElement.getAttribute(""data-bs-theme-mode""); } else { if ( localStorage.getItem(""data-bs-theme"") !== null ) { themeMode = localStorage.getItem(""data-bs-theme""); } else { themeMode = defaultThemeMode; } } if (themeMode === ""system"") { themeMode = window.matchMedia(""(prefers-color-scheme: dark)"").matches ? ""dark"" : ""light""; } document.documentElement.setAttribute(""data-bs-theme"", themeMode); }</script>
						<div class=""d-flex flex-column flex-root"" id=""kt_app_root"">
							<div class=""d-flex flex-column flex-column-fluid"">
								<div class=""scroll-y flex-column-fluid px-10 py-10"" data-kt-scroll=""true"" data-kt-scroll-activate=""true"" data-kt-scroll-height=""auto"" data-kt-scroll-dependencies=""#kt_app_header_nav"" data-kt-scroll-offset=""5px"" data-kt-scroll-save-state=""true"" style=""background-color:#D5D9E2; --kt-scrollbar-color: #d9d0cc; --kt-scrollbar-hover-color: #d9d0cc"">
									<style>html,body { padding:0; margin:0; font-family: Inter, Helvetica, ""sans-serif""; } a:hover { color: #009ef7; }</style>
									<div id=""#kt_app_body_content"" style=""background-color:#D5D9E2; font-family:Arial,Helvetica,sans-serif; line-height: 1.5; min-height: 100%; font-weight: normal; font-size: 15px; color: #2F3044; margin:0; padding:0; width:100%;"">
										<div style=""background-color:#ffffff; padding: 45px 0 34px 0; border-radius: 24px; margin:40px auto; max-width: 600px;"">
											<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" height=""auto"" style=""border-collapse:collapse"">
												<tbody>
													<tr>
														<td align=""center"" valign=""center"" style=""text-align:center; padding-bottom: 10px"">
															<div style=""text-align:center; margin:0 15px 34px 15px"">
																<div style=""margin-bottom: 50px"">
																	<a href=""#"" rel=""noopener"" target=""_blank"">
																		<img alt=""Logo"" src=""https://raw.githubusercontent.com/helmeyusopyp/talentbank/main/talentbanklogo.svg"" style=""height: 100px"" />
																	</a>
																</div>
																<div style=""font-size: 14px; font-weight: 500; margin-bottom: 27px; font-family:Arial,Helvetica,sans-serif;"">
																	<p style=""margin-bottom:9px; color:#181C32; font-size: 22px; font-weight:700"">Hi Marcus!</p>
																	<p style=""margin-bottom:2px; color:#7E8299"">Thank you for signing up with Talent Bank!</p>
																	<p style=""margin-bottom:2px; color:#7E8299"">Please confirm your email address by</p>
																	<p style=""margin-bottom:2px; color:#7E8299"">clicking link below</p>
																</div>
																<a href='authentication/general/welcome.html' target=""_blank"" style=""background-color:#50cd89; border-radius:6px;display:inline-block; padding:11px 19px; color: #FFFFFF; font-size: 14px; font-weight:500;"">Activate Account</a>
															</div>
														</td>
													</tr>
													<tr>
														<td align=""center"" valign=""center"" style=""font-size: 13px; text-align:center; padding: 0 10px 10px 10px; font-weight: 500; color: #A1A5B7; font-family:Arial,Helvetica,sans-serif"">
															<p style=""color:#181C32; font-size: 16px; font-weight: 600; margin-bottom:9px"">Contact Us</p>
															<p style=""margin-bottom:2px"">You may reach us at <a href=""mailto:info@yayasanpeneraju.com.my"" rel=""noopener"" target=""_blank"" style=""font-weight: 600"">info@yayasanpeneraju.com.my</a></p>
															<p style=""margin-bottom:2px"">Call our general number: +603 2727 9000</p>
															<p style=""margin-bottom:2px"">We serve Mon-Fri, 9AM-5:30PM</p>
														</td>
													</tr>
													<tr>
														<td align=""center"" valign=""center"" style=""font-size: 13px; padding:0 15px; text-align:center; font-weight: 500; color: #A1A5B7;font-family:Arial,Helvetica,sans-serif"">
															<p>&copy; Copyright Yayasan Peneraju</p>
														</td>
													</tr>
												</tbody>
											</table>
										</div>
									</div>
								</div>
							</div>
						</div>
						<script>var hostUrl = ""assets/"";</script>
						<script src=""https://peneraju.org/assets/plugins/global/plugins.bundle.js""></script>
						<script src=""https://peneraju.org/assets/js/scripts.bundle.js""></script>
					</body>
				</html>
			";
		}
	}
}
