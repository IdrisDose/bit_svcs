    <div class="container-fluid">
      <div class="col-sm-4 col-md-2 sidebar">
          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Job Menu</li>
            <li><a href="#" onclick="showTaskTable();"><span class="glyphicon glyphicon-search"></span> View Jobs</a></li>
            <li><a href="#" onclick="showNewTaskForm();"><span class="glyphicon glyphicon-plus"></span> Create a New Job</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-pencil"></span> Edit a Job</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-remove"></span> Delete a Job</a></li>
          </ul>
          <ul class="nav nav-sidebar dash-nav-men">
            <li class="list-header text-center">Invoice Menu</li>
            <li><a href="#"><span class="glyphicon glyphicon-search"></span> View Invoices</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-plus"></span> Create Invoice</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-pencil"></span> Edit Invoice</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-remove"></span> Delete Invoice</a></li>
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
                    <th>Job Description</th>
                    <th>Client Name</th>
                    <th>Supervisor of Job</th>
                    <th>Prority</th>
                    <th>Job Location</th>
                  </tr>
                </thead>
                <?php
                  foreach($j->getJobsE($id) as $job)
                  {
                    ?>
                      <tr>
                          <td>
                            <?php print_r($job["job_id"]); ?>
                          </td>
                          <td>
                            <?php print_r($job["job_details"]); ?>
                          </td>
                          <td>
                            <?php print_r($job["client"]); ?>
                          </td>
                          <td>
                            <?php print_r($job["supervisor"]); ?>
                          </td>
                          <td>
                            <?php print_r($job["priority"]); ?>
                          </td>
                          <td>
                            <?php print_r($job["location"]); ?>
                          </td>
                      </tr>
                    <?php
                  }
                ?>
              </table>
            </div>
          </div>
        </div>
      </div>
