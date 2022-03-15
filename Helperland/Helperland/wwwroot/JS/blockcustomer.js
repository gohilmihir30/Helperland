blockCustomerSuccess = (xhr) => {
	if (xhr.result) {
		location.reload();
	} else {
		$(".alert").html(xhr.error);
		$(".alert").fadeIn();
		$(".alert").delay(3000).fadeOut();
	}
};
blockCustomerError = (xhr) => {
	$(".alert").html(xhr.error);
	$(".alert").fadeIn();
	$(".alert").delay(3000).fadeOut();
};
