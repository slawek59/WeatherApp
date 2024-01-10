document.addEventListener("click",
	async function () {
		var id = document.activeElement.id
		var response = await fetch("details-dropdown/" + id);
		var index = await response.text();
		document.querySelector("." + id).innerHTML = index
	});

document.addEventListener("mouseout",
	async function () {
		var id = document.activeElement.id

		document.querySelector("." + id).innerHTML = null
	});
