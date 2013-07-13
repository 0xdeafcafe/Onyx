$(window).ready(function () { $(window).trigger('hashchange') });
$(window).on('hashchange', function () {
	if (!window.location.hash)
		return;

	var windowHash = window.location.hash.substring(2).toLowerCase();
	$('#nav-feat').removeClass('selected');
	$('#nav-create').removeClass('selected');
	$('#nav-about').removeClass('selected');

	if (windowHash.startsWith('create'))
		$('#nav-create').addClass('selected');
	else if (windowHash.startsWith('featured'))
		$('#nav-feat').addClass('selected');
	else if (windowHash.startsWith('about'))
		$('#nav-about').addClass('selected');
});
