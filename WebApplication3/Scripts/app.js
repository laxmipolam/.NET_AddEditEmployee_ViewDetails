var ViewModel = function () {
    var self = this;
    self.employees = ko.observableArray();
    self.error = ko.observable();

    var employeesUri = '/api/employees/';
    $('#inputDateOfBirth').datepicker();
    $('#inputDateOfJoining').datepicker();


    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllEmployees() {
        ajaxHelper(employeesUri, 'GET').done(function (data) {
            self.employees(data);
            $('#example').DataTable();
        });
    }

    // Fetch the initial data.
    getAllEmployees();
    self.detail = ko.observable();

    self.getEmployeeDetail = function (item) {
        ajaxHelper(employeesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.colleges = ko.observableArray();
    self.branches = ko.observableArray();
    self.streams = ko.observableArray();
    self.qualifications = ko.observableArray();

    self.newEmployee = {
        FirstName: ko.observable(),
        LastName: ko.observable(),
        DateOfBirth: ko.observable(),
        MobileNumber: ko.observable(),
        Gender: ko.observable(),
        Email:  ko.observable(),
        YearOfGraduating: ko.observable(),
        DateOfJoining: ko.observable(),
        Language: ko.observable(),
        IsActive: ko.observable(),
        CollegeId:  ko.observable(),
        StreamId: ko.observable(),
        BranchId: ko.observable(),
        QualificationId: ko.observable(),

    }

    var branchesUri = '/api/branches/';
    var collegesUri = '/api/colleges/';
    var streamsUri = '/api/streams/';
    var qualificationsUri = '/api/qualifications/';


    function getBranches() {
        ajaxHelper(branchesUri, 'GET').done(function (data) {
            self.branches(data);
        });
    }
    function getColleges() {
        ajaxHelper(collegesUri, 'GET').done(function (data) {
            self.colleges(data);
        });
    }
    function getStreams() {
        ajaxHelper(streamsUri, 'GET').done(function (data) {
            self.streams(data);
        });
    }
    function getQualifications() {
        ajaxHelper(qualificationsUri, 'GET').done(function (data) {
            self.qualifications(data);
        });
    }

    self.addEmployee = function (formElement) {
        var employee = {
            FirstName: self.newEmployee.FirstName(),
            LastName: self.newEmployee.LastName(),
            DateOfBirth: self.newEmployee.DateOfBirth(),
            MobileNumber: self.newEmployee.MobileNumber(),
            Gender: self.newEmployee.Gender(),
            Email: self.newEmployee.Email(),
            YearOfGraduating: self.newEmployee.YearOfGraduating(),
            DateOfJoining: self.newEmployee.DateOfJoining(),
            Language: self.newEmployee.Language(),
            IsActive: self.newEmployee.IsActive(),
            CollegeId: self.newEmployee.CollegeId().Id,
            StreamId: self.newEmployee.StreamId().Id,
            BranchId: self.newEmployee.BranchId().Id,
            QualificationId: self.newEmployee.QualificationId().Id,
        };

        ajaxHelper(employeesUri, 'POST', employee).done(function (item) {
            self.employees.push(item);
        });
    }

    self.editEmployeeDetail = function (data) {
        ajaxHelper(employeesUri + item.Id, 'PUT', employee).done(function (item) {
            self.detail(item);
        });
    }


    getColleges();
    getBranches();
    getStreams();
    getQualifications();
    
};

ko.applyBindings(new ViewModel());