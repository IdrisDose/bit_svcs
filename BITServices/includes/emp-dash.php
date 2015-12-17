<div class="container-fluid">
  <div class="col-sm-4 col-md-2 sidebar">
    <?php
      if(isset($_SESSION["ERROR_MESSAGE"]))
      {
        echo "<div id='error-message' class='alert alert-danger' role='alert'>
                <span class='glyphicon glyphicon-alert'></span> <strong>Oh snap!</strong>". $_SESSION['ERROR_MESSAGE']."
              </div>";
        unset($_SESSION["ERROR_MESSAGE"]);
      }elseif(isset($_SESSION["SUCCESS_MESSAGE"]))
      {
        echo "<div id='error-message' class='alert alert-success' role='alert'>
                {$_SESSION['SUCCESS_MESSAGE']}
              </div>";
        unset($_SESSION["SUCCESS_MESSAGE"]);
      }        
    ?>
      <ul class="nav nav-sidebar dash-nav-men">
        <li class="list-header text-center">Job Menu</li>
        <li><a href="#" onclick="showModule('showJobs')"><span class="glyphicon glyphicon-list"></span> View Jobs</a></li>
        <li><a href="#" onclick="showModule('newJob')"><span class="glyphicon glyphicon-plus"></span> Create a New Job</a></li>
        <li><a href="#" onclick="showModule('editJob')"><span class="glyphicon glyphicon-pencil"></span> Complete a Job</a></li>
        <?php if($isSupervisor) { ?>
        <li><a href="#" onclick="showModule('assignJob')"><span class="glyphicon glyphicon-pencil"></span> Assign a Job</a></li>
        <?php } ?>
      </ul>

      <?php
        if($isSupervisor)
        {
          ?>

          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Invoice Menu</li>
            <li><a href="#" onclick="showModule('viewInvoice')"><span class="glyphicon glyphicon-search"></span> View Invoices</a></li>
            <li><a href="#" onclick="showModule('createInvoice')"><span class="glyphicon glyphicon-plus"></span> Create New</a></li>
            <li><a href="#" onclick="showModule('editInvoice')"><span class="glyphicon glyphicon-pencil"></span> Edit Invoice</a></li>
            <li><a href="#" onclick="showModule('delInvoice')"><span class="glyphicon glyphicon-remove"></span> Delete Invoice</a></li>        
          </ul>

          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Staff Menu</li>
            <li><a href="#" onclick="showModule('viewStaff')"><span class="glyphicon glyphicon-search"></span> View Staff</a></li>
            <li><a href="#" onclick="showModule('createStaff')"><span class="glyphicon glyphicon-plus"></span> Create New</a></li>
            <li><a href="#" onclick="showModule('editSuper')"><span class="glyphicon glyphicon-wrench"></span> Edit Supervisor</a></li>
            <li><a href="#" onClick="showModule('editStaff')"><span class="glyphicon glyphicon-pencil"></span> Edit Staff</a></li>
            <li><a href="#" onClick="showModule('delStaff')"><span class="glyphicon glyphicon-remove"></span> Delete Staff</a></li>
          </ul>
      
          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Client Menu</li>
            <li><a href="#" onclick="showModule('viewClients')"><span class="glyphicon glyphicon-search"></span> View Clients</a></li>
            <li><a href="#" onclick="showModule('createClient')"><span class="glyphicon glyphicon-plus"></span> Create New</a></li>
            <li><a href="#" onClick="showModule('editClient')"><span class="glyphicon glyphicon-pencil"></span> Edit Client</a></li>
            <li><a href="#" onClick="showModule('delClient')"><span class="glyphicon glyphicon-remove"></span> Delete Client</a></li>
          </ul>
      <?php
        }
      ?>
  </div>
  
  <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
    <h1 class="page-header dash-header text-center"> Welcome, <?php echo $userName; ?> </h1>                
      <!-- Supervisor section -->
      <?php
      if($isSupervisor)
      {

        if(!$isSupervisor){
            $joblist = $j->getJobsE($id);
        } else { $joblist = $j->getJobsAll();}
      ?>

        <!-- assign a job -->
        <div class="row assign-task hidden">
          <p class="dash-header text-center text-medium"> Assign job to employee</p>
          <form class="center-form" action='php/assigntask.php' method='post' name='edittask' role='form'> 
            <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <select name="jobs" class="form-control">
                <?php
                  foreach($joblist as $jobs)
                  {
                    echo "<option value ={$jobs['job_id']}> {$jobs['job_name']} - {$jobs['job_details']} </option>";
                  } 
                ?>
              </select>
            </div>
            <br />
            <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <select name="staff_id" class="form-control">
                <?php
                  $stafflist = $e->getStaff();
                  foreach($stafflist as $staff)
                  {
                    
                    if($staff["isSupervisor"]) { $isSuper = "TRUE"; } else { $isSuper = "FALSE"; }
                    echo "<option value='{$staff['emp_id']}'> Staff Name: {$staff['emp_name']}</option>";
                  }
                ?>
              </select>
            </div>
            <br />
            <div class="col-md-7 checkbox">
              <label><input name="chk-conf" type="checkbox"> Assign job?</label>                        
            </div>
            <div class="col-md-5">
              <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
            </div>
          </form>
        </div>

        <div class="row new-invoice hidden">
        <p class="dash-header text-center text-medium"> Fill out the form below to create an invoice</p>
        <form class="center-form" action='php/createinvoice.php' method='post' name='createinvoice' role='form'>
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="job" class="form-control">
              <option> --- </option>
              <?php
                foreach($joblist as $job)
                {
                  echo "<option value ={$job['job_id']}> {$job['job_name']} - {$job['job_details']} </option>";
                } 
              ?>
            </select>
            
          </div> 
          <br />
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <input type="text" name="invdesc" placeholder="Invoice Details" class="form-control" required>
          </div>
          <br />                    
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <input type="text" name="invamount" placeholder="Invoice Amount $0.00" class="form-control" required>
          </div>                    
          <br />
          <div class="col-md-3">

          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>

        <div class="row staff-table hidden">    
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Staff ID</th>
                <th>Staff Title</th>
                <th>Staff Name</th>
                <th>Staff Email</th>
                <th>Staff Phone</th>
                <th>Staff Role</th>
                <th>Is Supervisor</th>
                <th>Is Admin</th>
                <th>Active</th>
              </tr>
            </thead>
            <?php
              $stafflist = $e->getStaff();
              foreach($stafflist as $staff)
              {
            ?>
                <tr>
                    <td><?php echo $staff["emp_id"]; ?></td>
                    <td><?php echo $staff["emp_title"]; ?></td>
                    <td><?php echo $staff["emp_name"]; ?></td>
                    <td><?php echo $staff["emp_email"]; ?></td>
                    <td><?php echo $staff["emp_phone"];?></td>
                    <td><?php echo $staff["emp_role"]; ?></td>
                    <td><?php echo $staff["isSupervisor"]; ?></td>
                    <td><?php echo $staff["isadmin"]; ?></td>
                    <td><?php echo $staff["active"]; ?></td>
                </tr>
            <?php
              }
            ?>
          </table>
        </div>
      </div>

      <div class="row client-table hidden">    
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Client ID</th>
                <th>Client Title</th>
                <th>Client Name</th>
                <th>Client Address</th>
                <th>Client City</th>
                <th>Client Postcode</th>
                <th>Client Email</th>
                <th>Client Phone</th>
                <th>Client Mobile</th>
                <th>Active</th>
              </tr>
            </thead>
            <?php
              $clientlist = $c->getClients();
              foreach($clientlist as $client)
              {
            ?>
                <tr>
                    <td><?php echo $client['cl_id']; ?></td>
                    <td><?php echo $client['cl_title']; ?></td>
                    <td><?php echo $client['cl_name']; ?></td>
                    <td><?php echo $client['cl_address']; ?></td>
                    <td><?php echo $client['cl_city']; ?></td>
                    <td><?php echo $client['cl_postcode']; ?></td>
                    <td><?php echo $client['cl_email']; ?></td>
                    <td><?php echo $client['cl_phone']; ?></td>
                    <td><?php echo $client['cl_mobile']; ?></td>
                    <td><?php echo $client['cl_active']; ?></td>
                </tr>
            <?php
              }
            ?>
          </table>
        </div>
      </div>
      <!-- Invoice Table display -->
      <div class="row invoice-table hidden">    
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Invoice ID</th>
                <th>Invoice Details</th>
                <th>Invoice Amount</th>
                <th>Invoice Status</th>
                <th>Job Name</th>
              </tr>
            </thead>
            <?php
              $invlist = $i->getInvoicesE();
              foreach($invlist as $inv)
            {
            ?>
              <tr>
                <td>
                  <?php echo $inv["inv_id"]; ?>
                </td>
                <td>
                  <?php echo '$'.$inv["inv_amount"]; ?>
                </td>
                <td>
                  <?php echo $inv["inv_details"]; ?>
                </td>
                <td>
                  <?php 
                    if($inv['inv_status'] == 'PAID')
                    {
                      
                      echo "<span class='alert-success'>{$inv["inv_status"]}</span>";

                    } elseif($inv["inv_status"] == 'PENDING') 
                    {

                      echo "<span class='alert-info'>{$inv["inv_status"]}</span>";

                    } elseif($inv["inv_status"] == 'UNPAID')
                    {

                      echo "<span class='alert-danger'>{$inv["inv_status"]}</span>";

                    }
                  ?>
                </td>
                <td>
                  <?php echo $inv["job_name"]; ?>
                </td>
              </tr>
          <?php
            } 
          ?>
          </table>
        </div>
      </div>

      <!-- Edit Supervisor -->
      <div class="row edit-super hidden">
        <p class="dash-header text-center text-medium"> Select supervisor to edit</p>
        <form class="center-form" action='php/makesuper.php' method='post' name='edittask' role='form'> 
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="staffid" class="form-control">
              <option> --- </option>
              <?php
                foreach($stafflist as $staff)
                {
                    if($staff["isSupervisor"]) { $isSuper = "TRUE"; } else { $isSuper = "FALSE"; }
                    echo '<option value="{$staff["emp_id"]}"> Staff Name: '. $staff["emp_name"].'; Staff ID:'. $staff["emp_id"] . '; Is Supervisor: ' . $isSuper .'</option>';
                }
              ?>
            </select>
          </div>
          <br />
          <div class="col-md-7 checkbox">
            <label><input name="confirmation-check" type="checkbox"> Is Supervisor?</label>                        
          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>

      <!-- Delete Staff -->
      <div class="row del-staff hidden">
        <p class="dash-header text-center text-medium"> Select staff member to delete</p>
        <form class="center-form" action='php/delstaff.php' method='post' name='edittask' role='form'> 
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="staffnames" class="form-control">
              <option> --- </option>
              <?php
                foreach($stafflist as $staff)
                {
                  
                  if($staff["isSupervisor"]) { $isSuper = "TRUE"; } else { $isSuper = "FALSE"; }
                  echo '<option value="{$staff["emp_id"]}"> Staff Name: '. $staff["emp_name"].'; Staff ID:'. $staff["emp_id"] . '; Is Supervisor: ' . $isSuper .'</option>';
                }
              ?>
            </select>
          </div>
          <br />
          <div class="col-md-7 checkbox">
            <label><input name="confirmation-check" type="checkbox"> Delete Staff?</label>                        
          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>

      <!-- Delete client -->
      <div class="row del-client hidden">
        <p class="dash-header text-center text-medium"> Select job to delete</p>
        <form class="center-form" action='php/delstaff.php' method='post' name='edittask' role='form'> 
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="clientids" class="form-control">
              <option> --- </option>
              <?php
                foreach($clientlist as $client)
                {
                  echo "<option value='{$client['cl_id']}'>{$client['cl_title']} {$client['cl_name']} - {$client['cl_email']}</option>";
                }
              ?>
            </select>
          </div>
          <br />
          <div class="col-md-7 checkbox">
            <label><input name="confirmation-check" type="checkbox"> Delete Client?</label>                        
          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>
    <?php
    } 
    ?>


    <div class="row task-table">    
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Job ID</th>
                <th>Job Name</th>
                <th>Job Description</th>
                <th>Client Name</th>
                <th>Employee</th>
                <th>Prority</th>
                <th>Job Location</th>
                <th>Active</th>
              </tr>
            </thead>
            <?php

              $joblistE = $j->getJobsE($id);
            
                foreach($joblistE as $jobe)
                {

                ?>
                  <tr>
                      <td>
                        <?php print_r($jobe["job_id"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["job_name"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["job_details"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["client"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["employee"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["priority"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["location"]); ?>
                      </td>
                      <td>
                        <?php print_r($jobe["active"]); ?>
                      </td>
                  </tr>
                <?php
              }
            ?>
          </table>
        </div>
      </div>

      <!-- Edit a job -->
      <div class="row edit-task hidden">
        <p class="dash-header text-center text-medium"> Submit job as complete</p>
        <form class="center-form" action='php/edittask.php' method='post' name='edittask' role='form'> 
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="job" class="form-control">
              <option> --- </option>
              <?php
                foreach($joblist as $job)
                {
                  echo "<option value = {$job['job_id']}> {$job['job_name']} - {$job['job_details']} </option>";
                } 
              ?>
            </select>
          </div>
          <br />
          <div class="col-md-7 checkbox">
            <label><input name="chk-conf" type="checkbox"> Job Complete?</label>                        
          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>

      <!-- New job -->
      <div class="row new-task hidden">
        <p class="dash-header text-center text-medium"> Fill out the form below to submit a new job request</p>
        <form class="center-form" action='php/newjobAdmin.php' method='post' name='newtask' role='form'> 
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <input type="text" name="jobdesc" placeholder="Job Details" class="form-control" required>
          </div>
          <br />          
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="client_id" class="form-control">
              <?php
                foreach($clientlist as $client)
                {
                  echo "<option value='{$client['cl_id']}'>{$client['cl_title']} {$client['cl_name']} - {$client['cl_email']}</option>";
                }
              ?>
            </select>
          </div>
          <input type="hidden" name="client_name" class="hidden" value="<?php echo $userName; ?>">
          <input type="hidden" name="super_id" class="hidden" value="<?php echo $_SESSION["employee"]["emp_id"]; ?>">
          <br />
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="staff_id" class="form-control">
              <?php
                foreach($stafflist as $staff)
                {
                  
                  if($staff["isSupervisor"]) { $isSuper = "TRUE"; } else { $isSuper = "FALSE"; }
                  echo "<option value='{$staff['emp_id']}'> Staff Name: {$staff['emp_name']}</option>";
                }
              ?>
            </select>
          </div>
          <br />                    
          <div class="input-group">
              <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
              <input type="text" name="jobloc" placeholder="Address e.g; 123 Something St, Hornsby" class="form-control">
          </div>                    
          <br />
          <div class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
            <select name="priority" class="form-control" required>
              <option> --- </option>
              <option value="LOW">Low</option>
              <option value="MEDIUM">Medium</option>
              <option value="HIGH">High</option>
            </select>
          </div>
          <br />
          <div class="col-md-7 checkbox">
            <label><input name="news-letter" type="checkbox"> Email a copy of the job request</label>                        
          </div>
          <div class="col-md-5">
            <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
          </div>
        </form>
      </div>

    <div class="row not-available hidden">
        <p class="dash-header text-center text-medium alert alert-danger" role='alert'><span class='glyphicon glyphicon-alert'></span> <STRONG> Oh Snap! </STRONG> Function Not Available at the moment. Sorry.</p>
    </div>
  </div>
</div>
