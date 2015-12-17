    <div class="container-fluid">
      <div class="col-sm-4 col-md-2 sidebar">
        <?php
          if(isset($_SESSION["ERROR_MESSAGE"]))
          {
            echo "<div id='error-message' class='alert alert-danger' role='alert'>
                    <span class='glyphicon glyphicon-alert'></span> <strong>Oh snap!</strong> {$_SESSION['ERROR_MESSAGE']}
                  </div>";
            unset($_SESSION["ERROR_MESSAGE"]);
          }elseif(isset($_SESSION["SUCCESS_MESSAGE"]))
          {
            echo "<div id='success-message' class='alert alert-success' role='alert'>
                    {$_SESSION['SUCCESS_MESSAGE']}
                  </div>";
            unset($_SESSION["SUCCESS_MESSAGE"]);
          }        
        ?>
          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Job Menu</li>
            <li><a href="#" onclick="showModule('showJobs')"><span class="glyphicon glyphicon-list"></span> View Jobs</a></li>
            <li><a href="#" onclick="showModule('newJob')"><span class="glyphicon glyphicon-plus"></span> Request a job</a></li>
            <li><a href="#" onclick="showModule('delJob')"><span class="glyphicon glyphicon-remove"></span> Delete a Job</a></li>
          </ul>
          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Invoice Menu</li>
            <li><a href="#" onclick="showModule('viewInvoice')"><span class="glyphicon glyphicon-search"></span> View Invoices</a></li>
            <li><a href="#" onclick="showModule('payInvoice')"><span class="glyphicon glyphicon-usd"></span> Pay Invoice</a></li>
          </ul>
      </div>
      <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
        <h1 class="page-header dash-header text-center"> Welcome, <?php echo $userName; ?> </h1> 
        

        <div class="row task-table">    
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Job ID</th>
                <th>Job Name</th>
                <th>Job Description</th>
                <th>Employee</th>
                <th>Prority</th>
                <th>Job Location</th>
                <th>Active</th>
              </tr>
            </thead>
            <?php
              $joblist = $j->getJobs($id);
              foreach($joblist as $job)
              {

                ?>
                  <tr>
                      <td>
                        <?php print_r($job["job_id"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["job_name"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["job_details"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["employee"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["priority"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["location"]); ?>
                      </td>
                      <td>
                        <?php print_r($job["active"]); ?>
                      </td>
                  </tr>
                <?php
              }
            ?>
          </table>
        </div>
      </div>
        
          <!-- New job -->
          <div class="row new-task hidden">
            <p class="dash-header text-center text-medium"> Fill out the form below to submit a new job request</p>
            <form class="center-form" action='php/newjob.php' method='post' name='newtask' role='form'> 
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="jobdesc" placeholder="Job Details" class="form-control" required>
              </div>


              <input type="hidden" class="hidden" name="client_id" value="<?php echo $_SESSION['client']['cl_id'] ?>"/>
              <input type="hidden" class="hidden" name="client_name" value="<?php echo $_SESSION['client']['cl_name'] ?>"/> 
              

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

          <!-- Edit a job -->
          <div class="row edit-task hidden">
            <p class="dash-header text-center text-medium"> Fill out the form below to submit an edit job request</p>
            <form class="center-form" action='php/edittask.php' method='post' name='edittask' role='form'> 
              <div class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                <select name="jobnames" class="form-control">
                  <option> --- </option>
                  <?php
                    foreach($joblist as $jobs)
                    {
                      echo '<option value="{$jobs["job_id"]}">'.$jobs["job_id"].' - '. $jobs["job_details"] .'</option>';
                    } 
                  ?>
                </select>
              </div>
              <br />
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="jobdesc" placeholder="Job Details" class="form-control" required>
              </div>
              <br />                    
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="jobloc" placeholder="Job Location" class="form-control" required>
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
                <label><input name="email-a-copy" type="checkbox"> Email a copy of the job request</label>                        
              </div>
              <div class="col-md-5">
                <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
              </div>
            </form>
          </div>

          <!-- Delete a job -->
          <div class="row delete-task hidden">
            <p class="dash-header text-center text-medium"> Select job to delete</p>
            <form class="center-form" action='php/deletetask.php' method='post' name='edittask' role='form'> 
              <div class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                <select name="job" class="form-control">
                  <option> --- </option>
                  <?php
                    foreach($joblist as $jobs)
                    {
                      echo "<option value ={$jobs['job_id']}> {$jobs['job_name']} - {$jobs['job_details']} </option>";
                    }
                  ?>
                </select>
              </div>
              <br />
              <div class="col-md-7 checkbox">
                <label><input name="confirmation-check" type="checkbox" requried> Are you sure you want to delete?</label>                        
              </div>
              <div class="col-md-5">
                <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
              </div>
            </form>
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
                  <th>Job ID</th>
                </tr>
              </thead>
                  <?php
                    $invlist = $i->getInvoices($id);
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
                          <?php echo $inv["job_id"]; ?>
                        </td>
                      </tr>
                  <?php
                    } 
                  ?>
              </table>
            </div>
          </div>

          <!-- Pay Invoice -->
          <div class="row invoice-pay hidden">
            <p class="dash-header text-center text-medium"> Select the invoice and click pay. Leave blank for paypal payment.</p>
            <form class="center-form" action='php/payinvoice.php' method='post' name='payinvoice' role='form'> 
              <div class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                <select name="invoice" class="form-control">
                  <option> --- </option>
                  <?php
                    foreach($invlist as $inv)
                    {
                      if($inv["inv_id"] != "NULL" && $inv['inv_status'] != 'PAID')
                      {
                        echo "<option value='{$inv['inv_id']}'> {$inv['inv_id']} - {$inv['inv_details']} - {$inv['inv_status']} - \${$inv['inv_amount']}</option>";
                      }   
                    }
                  ?>
                </select>
              </div>
              <br />
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="cc-name" placeholder="Card Name" class="form-control">
              </div>                    
              <br />
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="cc-details" placeholder="Card Number" class="form-control">

                  <span class="input-group-addon"><i class="glyphicon glyphicon-chevron-right"></i></span>
                  <input type="text" name="ccvno" placeholder="CCV" class="form-control">
              </div>                    
              <br />
              <div class="col-md-7 checkbox">
                <label><input name="paypal" type="checkbox"> Want to pay by paypal?</label>                        
              </div>
              <div class="col-md-5">
                <button class="btn btn-cta-primary pull-right" type="submit">Submit</button>                      
              </div>
            </form>
          </div>

        </div>
      </div>
