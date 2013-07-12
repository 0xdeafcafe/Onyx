$(window).ready(function () { $(window).trigger('hashchange') });
$(window).on('hashchange', function () {
	if (!window.location.hash)
		return;

	var windowHash = window.location.hash.substring(2).toLowerCase();
	$('#nav-feat').removeClass('selected');
	$('#nav-create').removeClass('selected');

	switch (windowHash) {
		case 'create':
			$('#nav-create').addClass('selected');
			break;
		case 'featured':
			$('#nav-feat').addClass('selected');
			break;
	}
});