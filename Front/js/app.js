const log = (text, type) => ({text, type})

Vue.component('todo-item', {
	template:
	'\
    <li>\
      {{ name }} {{ description }} {{dataTask}} {{comments}}\
    </li>\
		',
 props: ['name','description','dataTask','comments'],
}
)
new Vue({
	el: '#app',
	data: {
		styleAlert: {backgroundColor: 'lightgreen'},
		errors:[],
		logs: [],
		fails:[],
		NewTaskName:null,
		NewTaskDescription:null,
		NewTaskDate:null,
		NewTaskComments:null,
		userLogin: null,
		userPassword: null,
		newTask: '',
		tasks: [
			{name:'Поход к врачу',description: 'Врач хирург',dataTask: '05.05.2020',comments: ''},
			{name:'Позвонить маме',description: 'Номер +7(+++)+++++++',dataTask: '07.05.2020',comments: ''},
			{name:'Поход в бар', description:'Посиделки',dataTask: '10.05.2020', comments:''}
				],
		selectedTaskIndex: '',
		cardVisibility: false,
		formautoriz: true,
		nameform: false,
		btform: false,
		search: '',
		jnlVisibility: false,
		FormNewTask: false
	},

methods: {
		selectTask: function(index) {
			this.selectedTaskIndex = index
			this.task = this.filteredTasks[index]
		},

checkForm: function (e) {
		      this.errors = [];
		      if (!this.userLogin) {
		        this.errors.push('Укажите логин.');
		      }
		      if (!this.userPassword) {
		        this.errors.push('Укажите пароль.');
		      } else if (!this.validLogin(this.userLogin)) {
		        this.errors.push('Некорректный логин.');
		      }
		      if (!this.errors.length) {
						this.formautoriz = false;
						this.btform = true;
						this.nameform = true;
		        return true;
		      }
		      e.preventDefault();
},


validLogin: function (userLogin) {
		      var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		      return re.test(userLogin);
},

makeNewTask: function(f) {
				      this.fails = [];
				      if(!this.NewTaskName)
				        { this.fails.push("Название");}
				      if(!this.NewTaskDescription)
				        { this.fails.push("Описание");}
				      if(!this.NewTaskDate)
				        { this.fails.push("Дата");}
				      if (!this.fails.length) {
				      this.tasks.push({
				      name: this.NewTaskName,
				      description: this.NewTaskDescription,
				      dataTask: this.NewTaskDate,
				      comments: this.NewTaskComments,
				      })
								f.preventDefault()
							this.logs.push(
									log(`Вы создали событие: ${this.NewTaskName}`)
							)
				      this.NewTaskName='',
				      this.NewTaskDescription='',
				      this.NewTaskDate='',
				      this.NewTaskComments='',
							styleAlert='false'
				  }
},

deleteOrder: function(selectedTaskIndex){
	 this.$delete(this.tasks, selectedTaskIndex);
			this.logs.push(
				log(`Вы удалили событие: ${this.task.name}`)
										)
				cardVisibility='false'
		}
},

computed: {
		filteredTasks() {
			var searchTemplate = this.search.toLowerCase();
				return this.tasks.filter((task) => {
				return task.name.toLowerCase().includes(searchTemplate) || task.description.toLowerCase().includes(searchTemplate)
			})
										}
},

})
