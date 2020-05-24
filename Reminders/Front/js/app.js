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
		NewTaskName: '',
		NewTaskDescription: '',
		NewTaskDate: '',
		NewTaskComments: '',
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
		makeNewTask: function() {
			this.tasks.push({ 
				name: this.NewTaskName,
				description: this.NewTaskDescription,
				dataTask: this.NewTaskDate,
				comments: this.NewTaskComments,
			})
			this.NewTaskDate =''
			this.NewTaskDescription=''
			this.NewTaskDate=''
			this.NewTaskComments=''
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
