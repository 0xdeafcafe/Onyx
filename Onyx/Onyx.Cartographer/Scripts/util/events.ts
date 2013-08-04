///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="../jquery.cookie.d.ts" />
///<reference path="modal_manager.ts" />

/* jQuery file validation
----------------------------------------------- */
window.onload = () => {
	document.getElementById("project-stfs-upload").addEventListener("change", (event: any) => {
		var stfsFile: File = event.target.files[0];

		XboxInternals.IO.FileIO.LoadFromFile(stfsFile, (io) => {
			try {
				var stfs = new XboxInternals.Stfs.StfsPackage(io, 0);
				var cartographer = new Onyx.Cartographer(stfs);
				// Set Data In Window
				$("#stfs-preview > #stfs-name").text(cartographer.StfsPackage.metaData.displayName);
				$("#stfs-preview > #stfs-title").text(cartographer.StfsPackage.metaData.titleName);
				$("#stfs-preview > #stfs-author").text(cartographer.StfsPackage.metaData.publisherName);
				$("#stfs-preview > div > #stfs-icon").attr("src", "http://image-origin.xboxlive.com/global/t." + cartographer.StfsPackage.metaData.titleID.toString(16) + "/icon/0/8000");
			}
			catch (e) {

				// Remove File from uploader
				$("#project-stfs-upload").val("");

				// Remove data from validator
				$("#stfs-preview > #stfs-name").text("");
				$("#stfs-preview > #stfs-title").text("");
				$("#stfs-preview > #stfs-author").text("");
				$("#stfs-preview > div > #stfs-icon").attr("src", "");

				showModal(ModalTypes.ErrorModal, 'Invalid STFS Package or Gametype', 'The selected file was not a valid STFS Package or Halo 4 Gametype. Raw error is: <br /><br /> ' + e);
			}
		});
	});
};

/* Redrawing The Code Editor IDE
----------------------------------------------- */
$(document).ready(function () { reDrawCodeIde(); });
$(window).resize(function () { reDrawCodeIde(); });
function reDrawCodeIde() {
	console.log($(window).outerHeight());
	$(".CodeMirror").css("height", ($(window).outerHeight() - $(".nav-tabs").outerHeight() - $("#gamesaveModify > h1").outerHeight() - 130));
}

/* Profile Dropdown
----------------------------------------------- */
$('.user-header').click(function () {
	$('.submenu').css('display', 'block');
});
$(document).mouseup(function (e) {
	var container = $(".submenu");
	if (!container.is(e.target) && container.has(e.target).length === 0)
		container.hide();
});


/* Flash Messages
----------------------------------------------- */
$(document).ready(function () {
	$.each(new Array('Success', 'Error', 'Warning', 'Info'), function (i, alert) {

		// Get cookie
		var cookie = $.cookie("Flash." + alert);
		
		// If we have one, get data from it, yo
		if (cookie) {

			// get cookie data
			var flashMessage = cookie;
			var flashType = alert.toLocaleLowerCase();
			
			// delete cookie
			$.cookie("Flash." + alert, null, { path: '/' });

			// show modal
			showModalFromString(flashType, "Notification", flashMessage);

			// break out of this jai.. loop
			return;
		}
	});
});
