const log = (text, type) => ({text, type})


Vue.component('todo-item',{
	template: '\
    <li>\
      {{ name }} {{ description }} {{dataTask}} {{comments}}\
    </li>\
  ',
 props: ['name','description','dataTask','comments']
})

new Vue({
	el: '#app',
	data: {
		NewTaskName:null,
		logs: [],
		NewTaskDescription:null,
		NewTaskDate:null,
		NewTaskComments:null,
		errors:[],
		newTask: '',
		tasks: [
			{name:'Поход к врачу',description: 'Врач хирург',dataTask: '05.05.2020',comments: ''},
			{name:'Позвонить маме',description: 'Номер +7(+++)+++++++',dataTask: '07.05.2020',comments: ''},
			{name:'Туса в баре', description:'Бухич',dataTask: '10.05.2020', comments:''}
				],
		selectedTaskIndex: '',
		cardVisibility: false,
		search: '',
		jnlVisibility: false,
		FormNewTask: false
	},
	methods: {
		selectTask: function(index) {
			this.selectedTaskIndex = index
			this.task = this.filteredTasks[index]
		},



		makeNewTask: function(e) {

			this.tasks.push({
				name: this.NewTaskName,
				description: this.NewTaskDescription,
				dataTask: this.NewTaskDate,
				comments: this.NewTaskComments,
			})

			if(this.NewTaskName && this.NewTaskDescription && this.NewTaskDate) return true;
			      this.errors = [];
			      if(!this.NewTaskName) this.errors.push("Название.");
			      if(!this.NewTaskDescription) this.errors.push("Описание.");
						if(!this.NewTaskDate) this.errors.push("Дата.");
			      e.preventDefault();
		},




		newOrder: function(){
			this.logs.push(
				log(`Вы создали событие: ${this.NewTaskName}`, 'ok')
			)
		},
		deleteOrder: function(){
			this.logs.push(
				log(`Вы удалили событие: ${this.task.name}`, 'cnl')
			)
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
	filters: {
		NTDate(value) {
			return value.toLocaleString()
		}
	}
})
