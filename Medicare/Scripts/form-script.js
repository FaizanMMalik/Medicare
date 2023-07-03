/**
 * 
 */
 
 // import html2canvas from "html2canvas";
 
 
 // highlights the required input fields when the page is loaded
 function highlightRequired() {
	const requiredFields = [];
	requiredFields.push(document.querySelectorAll("input[type=text]"));
	requiredFields.push(document.querySelectorAll("input[type=date]"));
	requiredFields.push(document.querySelectorAll("select"));
	requiredFields.push(document.querySelectorAll("textarea"));
	
	for (let i = 0; i < requiredFields.length; i++) {
		for (let j = 0; j < requiredFields[i].length; j++) {
			if (requiredFields[i][j].hasAttribute("required")) {
				requiredFields[i][j].classList.add("required");
			}
		}
	}
}
 
 
 // used for automatically changing the primary (before the dash)
 // numbers of the ECN # input
 function fillECNPrimaryNums(inputId, outputId) {
	const input = document.getElementById(inputId);
	const output = document.getElementById(outputId);
	
	const length = input.value.length;
	
	if (length == 0) {
		output.innerHTML = " " + input.value + "XXXX -";
	} else if (length == 1) {
		output.innerHTML = " " + input.value + "XXX -";
	} else if (length == 2) {
		output.innerHTML = " " + input.value + "XX -";
	} else if (length == 3) {
		output.innerHTML = " " + input.value + "X -";
	} else {
		output.innerHTML = " " + input.value + " -";
	}
}

// switches the 'required' attribute's value between true
// and false
function toggleRequired(inputId) {
	const input = document.getElementById(inputId);
	
	if (input.hasAttribute("required")) {
		input.removeAttribute("required");
	} else {
		input.setAttribute("required", true);
	}
}

// changes the color of an input box when the box loses
// focus / blurs;
// method blur() already taken
function objBlur(inputId) {
	const input = document.getElementById(inputId);
	
	input.classList.remove("focused");
	input.classList.add("completed");
	
	// check if the input.value is empty
	// (is this the same for select as it is for input / textarea? ... check out tomorrow)
	//  - if not -> completed
	//  - else -> still required
	// 
}

// changes the color of an input box when it gets focused;
// similarly, method focus() already taken
function objFocus(inputId) {
	const input = document.getElementById(inputId);
	
	input.classList.remove("required");
	input.classList.remove("completed");
	input.classList.add("focused");
}

// switches the 'disabled' attributes value between true
// and false
function toggleDisabled(inputId) {
	const input = document.getElementById(inputId);
	
	const locked = input.hasAttribute("disabled");
	
	if (locked) {
		input.removeAttribute("disabled");
		input.removeAttribute("required");
		input.classList.remove("not-allowed");
	} else {
		input.setAttribute("disabled", true);
		input.classList.add("not-allowed");
		
		if (input.value) {
			input.value = "";
		}
	}
}


function toggleInputLock(inputId, outputIds, val) {
	const input = document.getElementById(inputId);
	
	if (input.value == val) {
		lockInput(outputIds);
	} else {
		unlockInput(outputIds);
	}
}


function lockInput(outputIds) {
	for (let i = 0; i < outputIds.length; i++) {
		document.getElementById(outputIds[i]).setAttribute("disabled", true);
		document.getElementById(outputIds[i]).classList.add("not-allowed");
	}
}


function unlockInput(outputIds) {
	for (let i = 0; i < outputIds.length; i++) {
		document.getElementById(outputIds[i]).removeAttribute("disabled");
		document.getElementById(outputIds[i]).classList.remove("not-allowed");
	}
}



