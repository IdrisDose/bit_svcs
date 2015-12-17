var signup_show;
var login_show;
var notAvailHidden = true;
var taskTableHidden = true;
var newTaskFormHidden = true;
var editTaskFormHidden = true;
var invTableHidden = true;
var invPayHidden = true;
var invCreateHidden = true;
var staffTableHidden = true;
var staffSuperHidden = true;
var staffDelHidden = true;
var clientTableHidden = true;
var jobAssignHidden = true;

function showPopup(type){
	switch(type){
		case "signup":
			if(login_show){
				$('#modal-login').addClass('hidden');
				$('#overlay').addClass('hidden');
				login_show = false;
			}
			if(signup_show)
			{
				$('#modal-signup').addClass('hidden');
				$('#overlay').addClass('hidden');
				signup_show = false;
			} else {
				$('#modal-signup').removeClass('hidden');
				$('#overlay').removeClass('hidden');
				signup_show = true;
			}
						
			break;
		case "login":
			if(signup_show)
			{
				$('#modal-signup').addClass('hidden');
				$('#overlay').addClass('hidden');
				signup_show = false;	
			}

			if(login_show)
			{
				$('#modal-login').addClass('hidden');
				$('#overlay').addClass('hidden');
				login_show = false;
			} else {
				$('#modal-login').removeClass('hidden');
				$('#overlay').removeClass('hidden');
				$('uname').focus();
				login_show = true;
			}
			
			
			break;
		default:
			break;
	}
}

function closePopup()
{
	if(signup_show)
	{
		$('#modal-signup').addClass('hidden');
		$('#overlay').addClass('hidden');
		signup_show = false;	
	}

	if(login_show)
	{
		$('#modal-login').addClass('hidden');
		$('#overlay').addClass('hidden');
		login_show = false;
	} 
}

function showTaskTable()
{
	
}

function showNewTaskForm()
{
	
}

function showEditTaskForm()
{
	
}

function showDeleteTaskForm()
{
	
}

function showInvTable()
{
	
}


function showModule(formName)
{
	switch(formName)
	{
		case "showJobs":
			if(taskTableHidden)
			{
				$('.task-table').show();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.invoice-table').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				taskTableHidden = false;
			} else
			{
				$('.task-table').hide();
				taskTableHidden = true;
			}
		break;

		case "newJob":
			if(newTaskFormHidden)
			{
				$('.new-task').removeClass('hidden');

				$('.task-table').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-table').hide();
				$('.new-task').show();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				newTaskFormHidden = false;

			} else {
				$('.new-task').hide();
				newTaskFormHidden = true;
			}
		break;

		//Edit Job Task	
		case "editJob":
			if(editTaskFormHidden)
			{
				$('.edit-task').removeClass('hidden');
				
				$('.task-table').hide();
				$('.new-task').hide();
				$('.delete-task').hide();
				$('.invoice-table').hide();
				$('.edit-task').show();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				editTaskFormHidden = false;

			} else {
				
				$('.edit-task').hide();
				editTaskFormHidden = true;
			}
		break;

		//Del Job Task
		case "delJob":
			if(editTaskFormHidden)
			{
				$('.delete-task').removeClass('hidden');

				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.invoice-table').hide();
				$('.delete-task').show();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				editTaskFormHidden = false;

			} else {
				
				$('.delete-task').hide();
				editTaskFormHidden = true;
			}
		break;
		
		//Create invoice form
		case "createInvoice":
			if(invCreateHidden)
			{
				$('.new-invoice').removeClass('hidden');

				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.invoice-table').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').show();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				invCreateHidden = false;
			} else {
				
				$('.new-invoice').hide();
				invCreateHidden = true;
			}
		break;

		//Pay invoice form
		case "payInvoice":
			if(invPayHidden)
			{
				$('.invoice-pay').removeClass('hidden');

				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.invoice-table').hide();
				$('.delete-task').hide();
				$('.new-invoice').hide()
				$('.invoice-pay').show();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				invPayHidden = false;

			} else {
				
				$('.invoice-pay').hide();
				invPayHidden = true;
			}
		break;

		//Invoice Table
		case "viewInvoice":
			if(invTableHidden)
			{
				$('.invoice-table').removeClass('hidden');

				$('.invoice-table').show();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				invTableHidden = false;
			} else
			{
				$('.invoice-table').hide();
				invTableHidden = true;
			}
		break;

		case "viewStaff":
			if(staffTableHidden)
			{
				$('.staff-table').removeClass('hidden');

				$('.staff-table').show();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				staffTableHidden = false;
			} else
			{
				$('.staff-table').hide();
				staffTableHidden = true;
			}
		break;
		
		case "editSuper":
			if(staffSuperHidden)
			{
				$('.edit-super').removeClass('hidden');

				$('.edit-super').show();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				staffSuperHidden = false;
			} else
			{
				$('.edit-super').hide();
				staffSuperHidden = true;
			}
		break;

		case "delStaff":
			if(staffDelHidden)
			{
				$('.del-staff').removeClass('hidden');

				$('.del-staff').show();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.client-table').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				staffDelHidden = false;
			} else
			{
				$('.del-staff').hide();
				staffDelHidden = true;
			}
		break;

		case "viewClients":
			if(clientTableHidden)
			{
				$('.client-table').removeClass('hidden');

				$('.client-table').show();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.not-available').hide();
				$('.assign-task').hide();
				clientTableHidden = false;
			} else
			{
				$('.client-table').hide();
				clientTableHidden = true;
			}
		break;

		case "assignJob":
			if(jobAssignHidden)
			{
				$('.assign-task').removeClass('hidden');

				$('.assign-task').show();
				$('.client-table').hide();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.not-available').hide();
				jobAssignHidden = false;
			} else
			{
				$('.assign-task').hide();
				jobAssignHidden = true;
			}
			break;

		default:
			if(notAvailHidden)
			{
				$('.not-available').removeClass('hidden');

				$('.not-available').show();
				$('.invoice-table').hide();
				$('.task-table').hide();
				$('.new-task').hide();
				$('.edit-task').hide();
				$('.delete-task').hide();
				$('.invoice-pay').hide();
				$('.new-invoice').hide();
				$('.staff-table').hide();
				$('.edit-super').hide();
				$('.del-staff').hide();
				$('.client-table').hide();
				$('.assign-task').hide();
				clientTableHidden = false;
			} else
			{
				$('.not-available').hide();
				clientTableHidden = true;
			}

		break;
	}
}