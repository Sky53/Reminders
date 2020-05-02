const task = (name, description, dat, comments) => ({name, description, dat, comments})

const tasks = [
	task('Поход к врачу.', 'Врач хирург.', '05.05.2020', ''),
	task('Позвонить маме.', 'Номер +7(+++)+++++++.', '07.05.2020', ''),
	task('Туса в баре.', 'Бухич.', '10.05.2020', ''),
]


new Vue({
	el: '#app',
	data: {
		tasks: tasks,
		task: tasks[0],
		selectedTaskIndex: 0,
		cardVisibility: false,
		search: '',
		jnlVisibility: false
	},
	methods: {
		selectTask: function(index) {
			this.selectedTaskIndex = index
			this.task = this.filteredTasks[index]
		}
	},
	computed: {
		filteredTasks() { 
			var searchTemplate = this.search.toLowerCase();
				return tasks.filter((task) => {
				return task.name.toLowerCase().includes(searchTemplate) || task.description.toLowerCase().includes(searchTemplate)
			})
		}
	}	
})