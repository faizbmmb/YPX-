using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentSearch.Core.Templates
{
	public static class RecoveryEmailTemplate
	{
		public static string EmailSurveyTemplate(string _Name, string _NRIC, string _Email, string _LOD, string _Link)
		{
			return $@"
			<html>
			<body>
				<p style=""margin-bottom:0px;"">Nama : <b>{_Name}</b></p>
				<p>Nombor Kad Pengenalan: <b>{_NRIC}</b></p>
				<p style=""font-size:15px;""><b>Notis Pembayaran Balik Skim Pembiayaan Pendidikan</b></p>
				<p>Berdasarkan Perjanjian Pembiayaan Pendidikan yang telah ditandatangani, Tuan/Puan dikehendaki membayar {_LOD}% daripada jumlah wang yang telah diperuntukkan.</p>
				<p>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disertakan Surat Tuntutan (Letter of Demand) yang mengandungi jumlah yang perlu dijelaskan bersama Jadual Bayaran Balik dan maklumat berkenaan cara-cara pembayaran. Selain itu, Tuan/Puan juga boleh membuat rayuan untuk penstrukturan semula bayaran.</p>
				<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pautan kepada Surat Tuntutan: <a href=""{_Link}"">{_Link}</a></p>
				<p>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tuan/Puan diminta untuk memberi maklumbalas mengenai penerimaan surat ini dan mengemukakan persetujuan untuk pembayaran pinjaman dalam tempoh 14 hari dari tarikh penerimaan emel ini kepada <a href=""mailto:recovery@yayasanpeneraju.com.my""><i>recovery@yayasanpeneraju.com.my</i></a>. Sekiranya tiada  maklumbalas  diterima dari Tuan/Puan, pihak Yayasan Peneraju akan menganggap Tuan/Puan bersetuju dengan notis pembayaran balik secara ansuran bulanan.</p>
				<p>4.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sebarang keputusan yang dikemukakan oleh pihak Yayasan Peneraju adalah muktamad. Sekiranya terdapat kemusykilan mengenai jumlah yang dinyatakan, Tuan/Puan boleh menghubungi kami di talian <a href=""tel:018-2231238"">018-2231238</a> untuk perbincangan lanjut.</p>
				<p>Terima kasih.</p>
				<p><i><b>THIS IS AN AUTOMATED EMAIL. PLEASE DO NOT REPLY TO THIS EMAIL.</b></i></p>

				<img alt=""Thumbnail Banner"" src=""https://demo.peneraju.org/assets/media/email/thumbnail_image.png"" style=""height: 170px""/>
			</body>
			</html>";
		}

	}
}
